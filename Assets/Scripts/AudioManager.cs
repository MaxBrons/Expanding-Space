using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   
    public static AudioSource Source;
    public AudioClip[] AudioArray;
    public AudioClip[] FXArray;

    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    public void PlayAudio(int audioClip)
    {
        Source.clip = AudioArray[audioClip];
        Debug.Log(Source.clip);
        Source.Play();
    }

    public void FXAudio(int FXClip)
    {
        Source.clip = AudioArray[FXClip];
        Debug.Log(Source.clip);
        Source.Play();
    }

}
