using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject rightHandWeapon;
    public GameObject leftHandWeapon;

    WeaponHolder rightHandSlot;
    WeaponHolder leftHandSlot;

    DamageCollider lefthandDamageCollider;
    public DamageCollider righthandDamageCollider;

    Enemy enemy;

    private void Awake()
    {
        WeaponHolder[] weaponHolderSlots = GetComponentsInChildren<WeaponHolder>();
        enemy = GetComponent<Enemy>();

        foreach (WeaponHolder weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHand)
            {
                leftHandSlot = weaponSlot;
            }

            else if (weaponSlot.isRightHand)
            {
                rightHandSlot = weaponSlot;
            }
        }
    }

    public void LoadEnemyWeapon(Weapon weapon, bool isleft)
    {
        if(isleft)
        {
            leftHandSlot.LoadWeapon(weapon);
            LoadEnemyWeaponDamage(true);
        }
        else
        {
            rightHandSlot.LoadWeapon(weapon);
            LoadEnemyWeaponDamage(false);
        }
    }

    public void LoadEnemyWeaponDamage(bool isleft)
    {
        if(isleft)
        {
            lefthandDamageCollider = leftHandSlot.currentWeapon.GetComponentInChildren<DamageCollider>();
        }
        else
        {
            righthandDamageCollider = rightHandSlot.currentWeapon.GetComponentInChildren<DamageCollider>();
        }
    }
    

    public void OpenDamageCollider()
    {
        righthandDamageCollider.OnEnableDamageCollider();
    }

    public void CloseDamageCollider()
    {
        righthandDamageCollider.OnDisableDamageColldier();
    }
}
