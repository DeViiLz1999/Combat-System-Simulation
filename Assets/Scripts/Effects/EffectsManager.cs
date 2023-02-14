using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public WeaponVFX currentWeaponVFX;
    public GameObject[] bloodSplatterVFXs;

    public virtual void PlayWeaponVFX(bool isWeaponInHand)
    {
        if(currentWeaponVFX != null)
        {
            currentWeaponVFX.PlayEffects();
        }
    }

    public virtual void PlayBloodSplatterVFX(Vector3 bloodLocation)
    {
        GameObject bloodSplatterVFX = bloodSplatterVFXs[Random.Range(0, bloodSplatterVFXs.Length)];
        GameObject blood = Instantiate(bloodSplatterVFX, bloodLocation, Quaternion.identity);
    }
}

