using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Weapon rightWeapon;
    public Weapon leftWeapon;

    WeaponManager weaponManager;

    private void Awake()
    {
        weaponManager = GetComponentInChildren<WeaponManager>();
    }

    private void Start()
    {
        weaponManager.LoadWeaponOnSlot(rightWeapon, false);
        weaponManager.LoadWeaponOnSlot(leftWeapon, true);  
    }
}
