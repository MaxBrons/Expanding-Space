using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroide : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject material;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 0.5f));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet hits the astroide, it will destroy the 
        //bullet and the astroide and spawn materials in
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject); //Destroy the bullet that hit the enemy
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); //Spawn in the explosion animation
            Instantiate(material, transform.position, Quaternion.identity); //Spawn in the material
            Vector3 pos = new Vector3(Random.Range(40, 75), Random.Range(40, 75), 0);
            Instantiate(gameObject, pos, Quaternion.identity); // Spawn in a new astroid in a range of 40f to 50f from the player
            Destroy(transform.gameObject); //Destroy the object
        }
    }
}
