using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip[] AudioArray;
    public AudioClip[] FXArray;
    int randomMusic;

    void Start()
    {
        //A random background song will be played
        if (gameObject.name == GameObject.Find("BackgroundMusic").name && SceneManager.GetActiveScene().buildIndex.Equals(1))
            RandomBackgroundMusic();
    }

    public void PlayAudio(int audioClip)
    {
        //Sets the Background song to a chosen song from the array
        Source = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        Source.clip = AudioArray[audioClip];
        Source.Play();
    }

    public void FXAudio(int FXClip)
    {
        //Sets the FX to a chosen FX from the array
        Source = GameObject.Find("SoundFXManagerObject").GetComponent<AudioSource>();
        Source.clip = FXArray[FXClip];
        Source.Play();
    }

    public void RandomBackgroundMusic()
    {
            //A random background song will be played
            Source = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            Source.clip = AudioArray[Random.Range(1,4)];
            Source.Play();
    }

}
