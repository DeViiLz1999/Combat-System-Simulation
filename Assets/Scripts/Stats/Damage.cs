using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 25;

    public AudioClip hurtClip;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();

        if(playerStats != null)
        {
            audioSource.PlayOneShot(hurtClip);
            playerStats.TakeDamage(damage);
        }
    }
}
