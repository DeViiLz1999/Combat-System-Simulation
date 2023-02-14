using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponVFX : MonoBehaviour
{
    public ParticleSystem WeaponTrail;

    public void PlayEffects()
    {
        WeaponTrail.Stop();

        if(WeaponTrail.isStopped)
        {
            WeaponTrail.Play();
        }
    }
}
