using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; //The speed the bullet travels with
    float maxDistance; //The maximum distance the bullet may travel

    void Update()
    {
        //Bullet will move
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        //If the bullet travels its maximum distance, it will be destroyed
        maxDistance += 1 * Time.deltaTime;
        if (maxDistance > 5)
            Destroy(gameObject);
    }
}
