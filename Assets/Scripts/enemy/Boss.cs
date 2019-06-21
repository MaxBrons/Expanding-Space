using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletBullet;

    [SerializeField] private float speed = 0.05f;
    [SerializeField] private float WaitToNextShot = 1f;

    int health;
    int attack;

    private bool follow = false;
    private bool mayShoot = true;

    void FixedUpdate()
    {
        if (follow)
        {
            //The enemy will move towards the player if in range of the trigger
            if ((player.transform.position - transform.position).sqrMagnitude > 25.0f)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            //The enemy will rotate towards the player properly if in range of the trigger
            Vector3 dir = player.transform.position - transform.position;
            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, zAngle);

            //The enemy will start shooting at the player
            if (mayShoot)
                StartCoroutine(Shoot());
        }
    }

    //If you trigger the collider than the enemy will follow the player
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            follow = true;
    }

    //If you stop triggering the collider the enemy will stop following the player
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            follow = false;
    }

    public IEnumerator Shoot()
    {
        mayShoot = false;
        //Spawn in the bullet
        Instantiate(bulletBullet, transform.position, transform.rotation);

        //Prevents the enemy from shooting to rapid
        yield return new WaitForSeconds(WaitToNextShot);
        mayShoot = true;
    }

    private void AllocateStats()
    {
        float healthMult = Random.value;
        float attackMult = Random.value;
        
        float multTotal = healthMult + attackMult;

        health = 3 + (int)((healthMult / multTotal) * (30 - 7 * 3));
        attack = 3 + (int)((attackMult / multTotal) * (30 - 7 * 3));
    }
}
