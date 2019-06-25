using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; //The speed the bullet travels with
    public GameObject bulletImpact;
    float maxDistance; //The maximum distance the bullet may travel

    void Update()
    {
        //Bullet will move
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //If the bullet travels its maximum distance, it will be destroyed
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If any object exept for the enemy is hit, the bullet impact will be instantiated
        if (collision.gameObject.tag == "PlayerSprite" || collision.gameObject.tag != "Enemy")
            Instantiate(bulletImpact, transform.position, Quaternion.identity);
    }

}
