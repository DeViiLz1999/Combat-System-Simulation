using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    WeaponHolder leftHand;
    WeaponHolder rightHand;

    DamageCollider currentDamageCollider;

    Enemy enemy;

    Player player;

    EffectsManager effectsManager;

    private void Awake()
    {
        WeaponHolder[] weaponHolderSlots = GetComponentsInChildren<WeaponHolder>();
        enemy = GetComponent<Enemy>();
        player = GetComponent<Player>();
        effectsManager = GetComponent<EffectsManager>();

        foreach(WeaponHolder weaponSlot in weaponHolderSlots)
        {
            if(weaponSlot.isLeftHand)
            {
                leftHand = weaponSlot;
            }

        else if(weaponSlot.isRightHand)
            {
                rightHand = weaponSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(Weapon weaponItem, bool isLeft)
    {
        if(isLeft)
        {
            // leftHand.LoadWeapon(weaponItem);
            return;
        }
        else
        {
            rightHand.LoadWeapon(weaponItem);
            LoadCurrentWeaponDamageCollider();
        }
    }

    private void LoadCurrentWeaponDamageCollider()
    {
        currentDamageCollider = rightHand.currentWeapon.GetComponentInChildren<DamageCollider>();
        effectsManager.currentWeaponVFX = rightHand.currentWeapon.GetComponentInChildren<WeaponVFX>();
    }

    public void OpenDamageCollider()
    {
        player.soundManager.PlayWhooshSoundFX();
        currentDamageCollider.OnEnableDamageCollider();
    }

    public void CloseDamageCollider()
    {
        currentDamageCollider.OnDisableDamageColldier();
    }

}
