using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; //The speed the bullet travels with
    public GameObject bulletImpact;

    void Update()
    {
        //Bullet will move
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If any object exept for the enemySprites is hit, the bullet impact will be instantiated
        if (collision.gameObject.tag == "PlayerSprite" || collision.gameObject.tag != "Enemy")
            Instantiate(bulletImpact, transform.position, Quaternion.identity);

        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet" && gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "EnemyRocket")
        {
            var Explosion = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().ExplosionAnim;
            Instantiate(Explosion,transform.position,Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        //If the bullet travels out of the screen, it will be destroyed
        Destroy(gameObject);
    }
}
