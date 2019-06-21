using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    public GameObject explosionPrefab;

    public int BossHealth = 3;
    public int minDmg = 1;
    public int maxDmg = 10;

    //If you trigger the collider than the enemy will follow the player
    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet hits the enemy, it will destroy the 
        //bullet and the enemy
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); //Destroy the bullet that hit the enemy
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); //Spawn in the explosion animation
            gameObject.GetComponent<spriteDirection>().enabled = false;
            Destroy(transform.parent.gameObject); //Destroy the parent object, so that the intire enemy will be destroyed
        }

        //Button pressed, lets deal some dmg.
        if (Input.GetKey(KeyCode.Space))
        {
            BossHealth -= Random.Range(minDmg, maxDmg);
            Debug.Log(BossHealth);
        }
    }
}
