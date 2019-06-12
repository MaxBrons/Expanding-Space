using UnityEngine;

public class Astroide : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject material;
    [SerializeField] private float range = 0f;

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

            // Spawn in a new astroid in a range from the player
            var randomPos = (Vector3)Random.insideUnitCircle * range;
            randomPos += transform.position;
            Instantiate(gameObject, randomPos, transform.rotation);

            Destroy(transform.gameObject); //Destroy the object
        }
    }
}
