using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float moveAmount;
    public float MouseX;
    public float MouseY;

    public float rollInputTimer;

    public bool b_Input;
    public bool jump_input;
    public bool lightAttack_Input;
    public bool heavyAttack_Input;
    public bool lockOn_Input;
    public bool blocking_Input;
    public bool taunt_Input;
    
    public bool rollFlag;
    public bool sprintFlag;
    public bool comboflag;
    public bool lockOnFlag;

    PlayerControls inputActions;
    PlayerAttack playerAttack;
    PlayerStats stats;
    Inventory inventory;
    Player player;
    CameraManager cameraManager;
    ThirdPersonController thirdPersonController;

    Vector2 movementInput;
    Vector2 cameraInput;

    private void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
        inventory = GetComponent<Inventory>();
        player = GetComponent<Player>();
        stats = GetComponent<PlayerStats>();
        cameraManager = FindObjectOfType<CameraManager>();
        thirdPersonController = GetComponent<ThirdPersonController>();
    }
    public void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerControls();
            inputActions.Playeractions.Move.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            inputActions.Playeractions.Look.performed += inputActions => cameraInput = inputActions.ReadValue<Vector2>();
        }

        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }

    public void TickInput(float delta)
    {
        MoveInput(delta);
        AttackInput(delta);
        JumpInput();
        //LockOnInput();
        HandleRollingInput(delta);
        BlockingInput();
        TauntInput();
    }

    private void MoveInput(float delta)
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));

        MouseX = cameraInput.x;
        MouseY = cameraInput.y;
    }

    private void HandleRollingInput(float delta)
    {
        b_Input = inputActions.Playercontrols.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Started;
        if(b_Input == true)
        {
            rollInputTimer += delta;
            sprintFlag = true;
        }

        else
        {
            if(rollInputTimer > 0 && rollInputTimer < 0.5f)
            {
                sprintFlag = false;
                rollFlag = true;
            }

            rollInputTimer = 0;
        }
    }

    private void AttackInput(float delta)
    {
        inputActions.Playercontrols.LightAttack.performed += i => lightAttack_Input = true;
        inputActions.Playercontrols.HeavyAttack.performed += i => heavyAttack_Input = true;


        if(stats.isDead == true)
        {
            return;
        }

        if(lightAttack_Input)
        {
            if(player.isCombo)
            {
                comboflag = true;
                playerAttack.HandleLightAttackCombo(inventory.rightWeapon); // Handle right hand weapons
                comboflag = false;
            }
            else
            {
                playerAttack.HandleLightAttack(inventory.rightWeapon);
            }
        }

        if(heavyAttack_Input)
        {
            if (player.isCombo)
            {
                comboflag = true;
                playerAttack.HandleHeavyAttackCombo(inventory.rightWeapon);
                comboflag = false;
            }
            else
            {
                playerAttack.HandleHeavyAttack(inventory.rightWeapon);
            }
        }
    }

    private void JumpInput()
    {
        inputActions.Playercontrols.Jump.performed += i => jump_input = true;
    }

    private void LockOnInput()
    {
        inputActions.Playercontrols.LockOn.performed += i => lockOn_Input = true;

        if(lockOn_Input && lockOnFlag == false)
        {
            
            lockOn_Input = false;
            
            if(cameraManager.nearestLockOnTargets != null)
            {
                cameraManager.currentLockOnTarget = cameraManager.nearestLockOnTargets; // if there is a potential lockOn target then do something
                lockOnFlag = true;
            }

            //cameraManager.HandleLockOn();
        }
        else if(lockOn_Input && lockOnFlag == true)
        {
            lockOn_Input = false;
            lockOnFlag = false;
            cameraManager.ClearLockOnTargets();
        }
    }

    private void BlockingInput()
    {
        inputActions.Playercontrols.Block.performed += i => blocking_Input = true;
        inputActions.Playercontrols.Block.canceled += i => blocking_Input = false;

        if (blocking_Input)
        {
            player.isBlocking = true;
            playerAttack.HandleBlocking();
        }

        else
        {
            player.isBlocking = false;
        }
    }

    private void TauntInput()
    {
        inputActions.Playercontrols.Taunt.performed += i => taunt_Input = true;

        if (taunt_Input)
        {
            player.isTaunting = true;
            //thirdPersonController.HandleTaunting();
        }
        else
        {
            player.isTaunting = false;
        }
    }
}
