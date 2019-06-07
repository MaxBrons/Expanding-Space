using UnityEngine;

public class MaterialResource : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UI.materials += 1;
            Destroy(gameObject);
        }
    }
}
