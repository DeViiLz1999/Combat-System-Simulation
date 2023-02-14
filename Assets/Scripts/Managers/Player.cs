using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    InputManager inputManager;
    Animator animator;

    CameraManager cameraManager;
    ThirdPersonController thirdPersonController;
    PlayerStats playerStats;

    [HideInInspector]
    public SoundManager soundManager;

    [Header("Player Flags")]
    public bool isInteracting;
    public bool isSprinting;
    public bool isInAir;
    public bool isGrounded;
    public bool isCombo;
    public bool isBlocking;
    public bool isTaunting;
    public bool isInvulerable;

    private void Awake()
    {
        cameraManager = CameraManager.instance;
    }

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        playerStats = GetComponent<PlayerStats>();  
        soundManager = GetComponent<SoundManager>();
    }

    void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = animator.GetBool("isInteracting");
        isCombo = animator.GetBool("isCombo");
        isInvulerable = animator.GetBool("isInvulerable");
        animator.SetBool("isInAir", isInAir);
        animator.SetBool("isBlocking", isBlocking);

        inputManager.TickInput(delta);
        thirdPersonController.HandleMovement(delta);
        thirdPersonController.HandleRollingAndSprinting(delta);
        thirdPersonController.HandleFalling(delta, thirdPersonController.moveDirection);
        thirdPersonController.HandleJumping();
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        if (cameraManager != null)
        {
            cameraManager.FollowTarget(delta);
            cameraManager.HandleCameraRotation(delta, inputManager.MouseX, inputManager.MouseY);
        }
    }

    private void LateUpdate()
    {
        inputManager.rollFlag = false;
        inputManager.sprintFlag = false;
        inputManager.lightAttack_Input = false;
        inputManager.heavyAttack_Input = false;
        inputManager.jump_input = false;

        if(isInAir)
        {
            thirdPersonController.inAirTime += Time.deltaTime;
        }
    }
}
