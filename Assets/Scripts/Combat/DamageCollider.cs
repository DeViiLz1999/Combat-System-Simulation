using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    Collider damageCollider;

    public int currentWeaponDamage = 10;

    private void Awake()
    {
        damageCollider = GetComponent<Collider>();
        damageCollider.gameObject.SetActive(true);
        damageCollider.isTrigger = true;
        damageCollider.enabled = false; // Collider is disable
    }

    public void OnEnableDamageCollider()
    {
        damageCollider.enabled = true;
    }

    public void OnDisableDamageColldier()
    {
        damageCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if(other.tag == "Player")
        {
           PlayerStats playerStats = other.GetComponent<PlayerStats>();
           

            if (playerStats != null)
            {

                playerStats.TakeDamage(currentWeaponDamage);
            }
        }*/

        if(other.tag == "Enemies")
        {
            EnemyStats enemyStats = other.GetComponent<EnemyStats>();
            Enemy enemy = other.GetComponent<Enemy>();
            EffectsManager enemyEffectsManager = other.GetComponent<EffectsManager>();

            if (enemyStats != null)
            {
                Vector3 contactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                enemyEffectsManager.PlayBloodSplatterVFX(contactPoint);
                enemy.soundManager.PlayDamageSoundFX();
                enemyStats.TakeDamage(currentWeaponDamage);
            }
        }
    }
}
