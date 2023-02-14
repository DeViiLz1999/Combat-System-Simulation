using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AnimatorManager am;
    Animator anim;
    InputManager inputManager;
    EffectsManager effectsManager;
    Player player;

    public string lastAttack;

    private void Start()
    {
        am = GetComponent<AnimatorManager>();
        anim = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        effectsManager = GetComponent<EffectsManager>();
        player = GetComponent<Player>();
    }

    #region Attack Actions
    public void HandleLightAttack(Weapon weapon)
    {
        am.PlayTargetAnimation(weapon.Light_Attack1, true);
        lastAttack = weapon.Light_Attack1;
        //Debug.Log(lastAttack);

        effectsManager.PlayWeaponVFX(false);
    }

    public void HandleHeavyAttack(Weapon weapon)
    {
        am.PlayTargetAnimation(weapon.Heavy_Attack1, true);
        lastAttack = weapon.Heavy_Attack1;
        //Debug.Log(lastAttack);

        effectsManager.PlayWeaponVFX(false);
    }

    public void HandleLightAttackCombo(Weapon weapon)
    {
        if(inputManager.comboflag)
        {
            am.am.SetBool("isCombo", false);

            if (lastAttack == weapon.Light_Attack1)
            {
                am.PlayTargetAnimation(weapon.Light_Attack2, true);
                lastAttack = weapon.Light_Attack2;
            }

            else if(lastAttack == weapon.Light_Attack2)
            {
                am.PlayTargetAnimation(weapon.Light_Attack3, true);
                lastAttack= weapon.Light_Attack3;
            }

            else if(lastAttack == weapon.Light_Attack3)
            {
                am.PlayTargetAnimation(weapon.Light_Attack4, true);
            }
        }

    }

    public void HandleHeavyAttackCombo(Weapon weapon)
    {
        if (inputManager.comboflag)
        {
            am.am.SetBool("isCombo", false);

            if (lastAttack == weapon.Heavy_Attack1)
            {
                am.PlayTargetAnimation(weapon.Heavy_Attack2, true);
                lastAttack = weapon.Heavy_Attack2;
            }

            else if (lastAttack == weapon.Heavy_Attack2)
            {
                am.PlayTargetAnimation(weapon.Heavy_Attack3, true);
                lastAttack = weapon.Heavy_Attack3;
            }

            else if (lastAttack == weapon.Heavy_Attack3)
            {
                am.PlayTargetAnimation(weapon.Heavy_Attack4, true);
            }
        }
    }
    #endregion


    #region Block Actions
    public void HandleBlocking()
    {
        PerformBlockingAction();
    }

    private void PerformBlockingAction()
    {
        if(player.isInteracting)
        {
            return;
        }

        if(player.isInAir)
        {
            return;
        }

        /*if(player.isBlocking)
        {
            return; // To avoid playing the animation every frame
        }*/

        if(player.isBlocking)
        {
            anim.Play("Blocking");
            player.isBlocking = true;
        }

    }
    #endregion
}
