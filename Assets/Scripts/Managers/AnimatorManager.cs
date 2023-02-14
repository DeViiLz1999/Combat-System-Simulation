using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    Player _player;
    InputManager inputManager;
    ThirdPersonController tpc;
    
    public GameManager gameManager;

    [HideInInspector]
    public Animator am;

    [HideInInspector]
    public bool canRotate;

    int horizontal;
    int vertical;

    public void Initialize()
    {
        _player = GetComponentInParent<Player>();
        am = GetComponent<Animator>();
        inputManager = GetComponentInParent<InputManager>();
        tpc = GetComponentInParent<ThirdPersonController>();
        horizontal = Animator.StringToHash("Horizontal");
        vertical = Animator.StringToHash("Vertical");
    }

    public void UpdateAnimator(float horizontalMovement, float verticalMovement, bool isSprinting)
    {
        // To clamp the values 
        float ver = 0;
        float hor = 0;

        if(verticalMovement > 0 && verticalMovement < 0.55f)
        {
            ver = 0.5f;
        }

        else if (verticalMovement > 0.55f)
        {
            ver = 1f;
        }

        else if(verticalMovement < 0 && verticalMovement > -0.55f)
        {
            ver = -0.5f;
        }

        else if(verticalMovement < -0.55f)
        {
            ver = -1;
        }

        else
        {
            ver = 0;
        }

        if (horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            hor = 0.5f;
        }

        else if (horizontalMovement > 0.55f)
        {
            hor = 1f;
        }

        else if (horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            hor = -0.5f;
        }

        else if (horizontalMovement < -0.55f)
        {
            hor = -1;
        }

        else
        {
            hor = 0;
        }

        if(isSprinting)
        {
            ver = 2;
            hor = horizontalMovement;
        }

        am.SetFloat(vertical, ver, 0.1f, Time.deltaTime);
        am.SetFloat(horizontal, hor, 0.1f, Time.deltaTime);
    }

    public void CanRotate()
    {
        canRotate = true;
    }

    public void StopRotation()
    {
        canRotate = false;
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        am.applyRootMotion = isInteracting;
        am.SetBool("isInteracting", isInteracting);
        am.CrossFade(targetAnimation, 0.2f);
    }

    private void OnAnimatorMove()
    {
        if(_player.isInteracting == false)
        {
            return;
        }

        if(gameManager.isGameOver == true)
        {
            return;
        }

        float delta = Time.deltaTime;
        tpc.rb.drag = 0;

        Vector3 deltaPosition = am.deltaPosition;
        deltaPosition.y = 0;

        Vector3 velocity = deltaPosition / delta;
        tpc.rb.velocity = velocity;
    }

    public void EnableCombo()
    {
        am.SetBool("isCombo", true);
    }

    public void DisableCombo()
    {
        am.SetBool("isCombo", false);
    }

    public void EnableInvulnerability()
    {
        am.SetBool("isInvulerable", true);
    }

    public void DisableInvulnerability()
    {
        am.SetBool("isInvulerable", false);
    }
}
