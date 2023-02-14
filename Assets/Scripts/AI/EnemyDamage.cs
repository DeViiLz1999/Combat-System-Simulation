using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 5;
    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        Player player = other.GetComponent<Player>();
        EffectsManager playerEffectsManager = other.GetComponent<EffectsManager>();

        if (playerStats != null)
        {
            //Detects and locks where the collider is strike
            Vector3 contactPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            playerEffectsManager.PlayBloodSplatterVFX(contactPoint);
            player.soundManager.PlayDamageSoundFX();
            playerStats.TakeDamage(damage);
        }
    }
}
