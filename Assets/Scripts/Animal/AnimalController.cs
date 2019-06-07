using UnityEngine;

public class AnimalController : MonoBehaviour
{

    public GameObject[] Animals;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
            Instantiate(this);
    }
}
