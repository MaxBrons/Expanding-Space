using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject explosionPrefab;

    //If you trigger the collider than the enemy will follow the player
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet hits the enemy, it will destroy the 
        //bullet and the enemy
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); //Destroy the bullet that hit the enemy
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); //Spawn in the explosion animation
            Destroy(transform.parent.gameObject); //Destroy the parent object, so that the intire enemy will be destroyed
        }
    }
}
