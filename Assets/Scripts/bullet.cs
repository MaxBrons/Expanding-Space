using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed; //The speed the bullet travels with
    float maxDistance; //The maximum distance the bullet may travel
    public bool enemyBullet = false;

    void Update()
    {
        //Bullet will move
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //If the bullet travels its maximum distance, it will be destroyed
        maxDistance += 1 * Time.deltaTime;
        if (maxDistance > 5)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyBullet)
        {
            if (collision.gameObject.tag == "PlayerSprite")
                Destroy(gameObject);
        }

        else if (!enemyBullet)
        {
            //If the bullet hits the enemy it will destroy the 
            // bullet and damage the enemy
            if (collision.gameObject.tag == "EnemySprite")
                Destroy(gameObject);
        }
    }
}
