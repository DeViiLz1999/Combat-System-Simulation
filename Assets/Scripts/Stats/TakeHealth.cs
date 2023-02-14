using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeHealth : MonoBehaviour
{
    public int healAmount = 50;
    public AudioClip healingSound;
    public AudioSource healingSource;

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        if(other.tag == "Player")
        {
            playerStats.HealPlayer(healAmount);
            healingSource.PlayOneShot(healingSound);
            Destroy(gameObject);
        }
    }
}
