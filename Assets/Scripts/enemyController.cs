﻿using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject player;
    public bool follow = false;
    public float speed = 0.05f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            follow = true;     
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            follow = false;
    }

    void FixedUpdate()
    {
        if (follow)
        {
            //The enemy will move towards the player if in range of the trigger
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            //The enemy will rotate towards the player properly if in range of the trigger
            Vector3 dir = player.transform.position - transform.position;
            dir.Normalize();
            float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.Euler(0, 0, zAngle);
        }
    }
        
}
