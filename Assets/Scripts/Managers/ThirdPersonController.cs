using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonController : MonoBehaviour
{
    Transform mainCamera;
    InputManager _inputManager;
    Animator anim;

    public Vector3 moveDirection;

    Vector3 normalPosition;
    Vector3 targetPosition;

    Player _player;

    [HideInInspector]
    public Transform myTransform;

    [HideInInspector]
    public Rigidbody rb;

    [HideInInspector]
    public GameObject normalCamera;

    [HideInInspector]
    public AnimatorManager _animatorManager;

    [Header("Locomotion Stats")]
    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float sprintSpeed = 9f;
    [SerializeField]
    float rotationSpeed = 10f;
    [SerializeField]
    float fallingSpeed = 45f;

    [Header("Landing Stats")]
    [SerializeField]
    float groundDetectionRayStartPoint = 0.5f; //Raycast will begin
    [SerializeField]
    float minDistToBeginFall = 1f; //Dist needed to start the fall anim
    [SerializeField]
    float groundDirectionRayDist = 0.2f; //Raycast offset
    LayerMask ignoreForGroundCheck;
    public float inAirTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
        _inputManager = GetComponent<InputManager>();
        _animatorManager = GetComponent<AnimatorManager>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main.transform;
        myTransform = transform;
        _animatorManager.Initialize();

        _player.isGrounded = true; // To prevent the anim to play as we start
        ignoreForGroundCheck = ~(1 << 8 | 1 << 11);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void HandleMovement(float delta)
    {
        if(_inputManager.rollFlag) // does not move when rolling
        {
            return;
        }

        if(_player.isInteracting) // does not move when falling
        {
            return;
        }

        if(_player.isBlocking)
        {
            return;
        }

        moveDirection = mainCamera.forward * _inputManager.verticalInput;
        moveDirection += mainCamera.right * _inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;

        float speed = movementSpeed;

        if(_inputManager.sprintFlag && _inputManager.moveAmount > 0.5f)
        {
            speed = sprintSpeed;
            _player.isSprinting = true;
            moveDirection *= speed;
        }

        else
        {
            if(_inputManager.moveAmount < 0.5f)
            {
                moveDirection *= movementSpeed;
                _player.isSprinting = false;
            }

            else
            {
                moveDirection *= speed;
                _player.isSprinting = false;
            }
            
        }


        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalPosition);
        rb.velocity = projectedVelocity;

        _animatorManager.UpdateAnimator(_inputManager.moveAmount, 0, _player.isSprinting);

        if (_animatorManager.canRotate)
        {
            HandleRotation(delta);
        }
    }

    public void HandleRotation(float delta)
    {
        Vector3 targetDirection = Vector3.zero;
        float movementOveride = _inputManager.moveAmount;

        targetDirection = mainCamera.forward * _inputManager.verticalInput * movementOveride;
        targetDirection += mainCamera.right * _inputManager.horizontalInput *  movementOveride;

        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
        {
            targetDirection = myTransform.forward;
        }

        float rs = rotationSpeed;

        Quaternion tr = Quaternion.LookRotation(targetDirection);
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

        myTransform.rotation = targetRotation;

    }

    public void HandleRollingAndSprinting(float delta)
    {
        if(_animatorManager.am.GetBool("isInteracting"))
        {
            return;
        }

        if(_inputManager.rollFlag)
        {
            moveDirection = mainCamera.forward * _inputManager.verticalInput;
            moveDirection += mainCamera.right * _inputManager.horizontalInput;

            if(_inputManager.moveAmount > 0)
            {
                _animatorManager.PlayTargetAnimation("Rolling", true);
                moveDirection.y = 0;
                Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = rollRotation;
            }
            else
            {
                _animatorManager.PlayTargetAnimation("Backflip", true);
            }
        }
    }

    public void HandleFalling(float delta, Vector3 moveDirection)
    {
        _player.isGrounded = false;
        RaycastHit hit;

        Vector3 origin = myTransform.position;
        origin.y += groundDetectionRayStartPoint;

        if(Physics.Raycast(origin, myTransform.forward, out hit, 0.4f))
        {
            moveDirection = Vector3.zero;
        }

        if(_player.isInAir)
        {
            rb.AddForce(-Vector3.up * fallingSpeed); //player will fall if in the air
            rb.AddForce(moveDirection * fallingSpeed / 12f); //player will be push off the ledge
        }

        Vector3 direction = moveDirection;
        direction.Normalize();
        origin += direction * groundDirectionRayDist;

        targetPosition = myTransform.position;

        Debug.DrawRay(origin, -Vector3.up * minDistToBeginFall, Color.blue, 0.1f, false);

        if (Physics.Raycast(origin, -Vector3.up, out hit, minDistToBeginFall, ignoreForGroundCheck))
        {
            normalPosition = hit.normal;
            Vector3 tP = hit.point;
            _player.isGrounded = true;
            targetPosition.y = tP.y;


            if (_player.isInAir)
            {
                if (inAirTime > 1f)
                {
                    Debug.Log("Air time: " + inAirTime);
                    _animatorManager.PlayTargetAnimation("Land", true);
                    //inAirTime = 0;
                }
                else
                {
                    _animatorManager.PlayTargetAnimation("Empty", false);
                    inAirTime = 0;
                }

                _player.isInAir = false;
            }
        }

        else
        {
            if (_player.isGrounded)
            {
                _player.isGrounded = false;
            }

            if (_player.isInAir == false)
            {
                if (_player.isInteracting == false)
                {
                    _animatorManager.PlayTargetAnimation("Falling", true);
                }

                Vector3 v = rb.velocity;
                v.Normalize();
                rb.velocity = v * (movementSpeed / 2);
                _player.isInAir = true;
            }
        }

        if(_player.isGrounded)
        {
            if(_player.isInteracting || _inputManager.moveAmount > 0)
            {
                myTransform.position = Vector3.Lerp(myTransform.position, targetPosition, Time.deltaTime);
            }

            else
            {
                myTransform.position = targetPosition;
            }
        }
    }

    public void HandleJumping()
    {
        if(_player.isInteracting)
        {
            return;
        }

        if(_inputManager.jump_input)
        {
            if(_inputManager.moveAmount > 0)
            {
                moveDirection = mainCamera.forward * _inputManager.verticalInput;
                moveDirection += mainCamera.right * _inputManager.horizontalInput;
                _animatorManager.PlayTargetAnimation("Jumping", true);
                moveDirection.y = 0;
                Quaternion jumpRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = jumpRotation;
            }
        }
    }

    public void HandleTaunting()
    {
        if(_player.isInteracting)
        {
            return;
        }


        if(_inputManager.taunt_Input && _player.isTaunting == true)
        {
            _animatorManager.PlayTargetAnimation("Taunt", true);
            _player.isTaunting = false;
        }
    }
}
