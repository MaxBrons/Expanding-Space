using UnityEngine;

public class MaterialResource : MonoBehaviour
{
    public AudioManager audioManager;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioManager.PlayAudio(10);
            UI.materials += 1;
            Destroy(gameObject);
        }
    }
}
