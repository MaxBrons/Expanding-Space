using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private LayerMask whatIsSolid;

    public float offset = 0;

    [SerializeField]
    private bool shoot_Normal = false, shoot_Rocket = false;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Handles the rotation
        Vector3 difference = player.transform.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        //Resets the z axis to 0
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void Update()
    {
        //Projectile movement
        if (shoot_Normal)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else if(shoot_Rocket)
            transform.Translate(Vector2.up * speed/1.3f * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        //If the bullet travels out of the screen, it will be destroyed
        Destroy(gameObject);
    }
}
