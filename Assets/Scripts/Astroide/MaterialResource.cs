using UnityEngine;

public class MaterialResource : MonoBehaviour
{
    public AudioManager FXAudioManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FXAudioManager.FXAudio(4);
            UI.materials += 1;
            Destroy(gameObject);
        }
    }
}
