using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip playerHitSound, FireSound, DeathSound, ExplosionSound;
    static AudioSource audioSrc;

     void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");

        FireSound = Resources.Load<AudioClip>("Fire");

        DeathSound = Resources.Load<AudioClip>("Death");

        ExplosionSound = Resources.Load<AudioClip>("Explosion");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Fire":
                audioSrc.PlayOneShot(FireSound);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case "Death":
                audioSrc.PlayOneShot(DeathSound);
                break;
            case "Explosion":
                audioSrc.PlayOneShot(ExplosionSound);
                break;
        }
    }
}
