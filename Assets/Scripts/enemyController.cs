using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject player;
    public bool follow = false;
    public float speed = 4;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision. == "Player")
            follow = true;     
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        follow = false;
    }

    void FixedUpdate()
    {
        if (follow)
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
    }
        
}
