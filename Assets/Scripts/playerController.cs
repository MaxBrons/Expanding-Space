using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Vector2 velocity = Vector2.zero;
    Vector2 force;
    Transform player;
    public GameObject bulletBullet;

    public float health = 3;
    public float speed = 3;
    public float maxVelocity = 5f;
    public float rotationSpeed = 20f;
    public float acceleration = 1f;

    public float WaitToNextShot = 1f;
    private bool mayShoot = true;
    private bool MayMoveNow = false;

    void Start()
    {
        //Hides the cursor and lockes the cursor to the bounderies of the gamescreen
        Cursor.lockState = CursorLockMode.Locked;

        //Gets the player's transform
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        //Sets the rotation of the player to the x position of the mouse
        float rotation = -Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        //If the W key is pressed trigger the player's movement
        //You stop the trigger when the W key is released
        if (Input.GetKeyDown(KeyCode.W))
            MayMoveNow = true;
        else if (Input.GetKeyUp(KeyCode.W))
        {
            MayMoveNow = false;
            velocity = Vector2.zero; //Resets the velocity of the player
        }

        if (MayMoveNow)
        {
            //Player moves forward when the W key is pressed
            force = Vector2.up * acceleration * Time.deltaTime;
            velocity += force;

            //Increases the movement speed over time
            velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
            transform.Translate(velocity * Time.deltaTime);
        }

        //You shoot when the left mouse button is pressed
        if (Input.GetButtonDown("Fire1") && mayShoot)
            StartCoroutine(Shoot());
    }

    public IEnumerator Shoot()
    {
        mayShoot = false;

        //Spawns in the bullet
        Instantiate(bulletBullet, transform.position, transform.rotation);

        //Prevents you from shooting to rapid
        yield return new WaitForSeconds(WaitToNextShot);
        mayShoot = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet hits the player, it will destroy the 
        //bullet and damage the player
        if (collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject);
            if (health != 0)
                health--;
            else
                Debug.Log("You Died");
        }
    }
}
