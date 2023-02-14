using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public Transform parentOveride;
    public bool isLeftHand;
    public bool isRightHand;

    public GameObject currentWeapon;


    public void LoadWeapon(Weapon weaponItem)
    {
       //Vector3 weaponScale = new(01620246, 01620246, 01620246);

        UnloadWeaponAndDestroy();

        if (weaponItem == null)
        {
            UnloadWeapon();
            return; // Loads the weapons model
        }

        GameObject model = Instantiate(weaponItem.model) as GameObject;

        if (model != null)
        {
            if (parentOveride != null)
            {
                model.transform.parent = parentOveride;
            }
            else
            {
                model.transform.parent = transform;
            }

            model.transform.localPosition = Vector3.zero;
            model.transform.localRotation = Quaternion.identity;
            model.transform.localScale = Vector3.one;
        }

        currentWeapon = model;
    }

    public void UnloadWeapon()
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);
        }
    }

    public void UnloadWeaponAndDestroy()
    {
        if(currentWeapon != null)
        {
            Destroy(currentWeapon);
        }
    }
}

