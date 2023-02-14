using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip damageSound;

    public AudioClip[] whooshSounds;
    private List<AudioClip> potentialWhooshSound;
    private AudioClip lastWhooshSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void PlayDamageSoundFX()
    {
        audioSource.PlayOneShot(damageSound, 0.5f);
    }

    public virtual void PlayWhooshSoundFX()
    {
        potentialWhooshSound = new List<AudioClip>();

        foreach(var whooshSound in whooshSounds)
        {
            if(whooshSound != lastWhooshSound)
            {
                potentialWhooshSound.Add(whooshSound); // prevents from playing same sound again
            }
        }

        int randomValue = Random.Range(0, potentialWhooshSound.Count);
        lastWhooshSound = whooshSounds[randomValue];
        audioSource.PlayOneShot(whooshSounds[randomValue]);
    }
}
