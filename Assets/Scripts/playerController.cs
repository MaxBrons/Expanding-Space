using System.Collections;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Vector2 velocity = Vector2.zero;
    Vector2 force;
    Transform player;
    public GameObject bulletBullet;
    public float health,speed = 3;
    public float maxVelocity = 5f;
    public float rotationSpeed = 20f;
    public float acceleration,fireRate = 1f;
    bool MayMoveNow = false;
    bool mayShoot = true;
    float currentTime = 0f;
    float step = 0.2f;

    void Start()
    {
        //Hides the cursor and lockes the cursor to the bounderies of the gamescreen
        Cursor.lockState = CursorLockMode.Locked;

        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Movement();
        StartCoroutine(Shoot());
    }

    public void Movement()
    {
        //Sets the rotation of the player to the x position of the mouse
        float rotation = -Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        if (Input.GetKeyDown(KeyCode.W))
        {
            MayMoveNow = true;
            velocity = Vector2.zero; //Resets the velocity of the player
        }
        else if (Input.GetKeyUp(KeyCode.W))
            MayMoveNow = false;

        if (MayMoveNow)
        {
            //Player moves forward when the W key is pressed
            force = Vector2.up * acceleration * Time.deltaTime;
            velocity += force;
            velocity = Vector2.ClampMagnitude(velocity, maxVelocity);//Increases speed over time
            transform.Translate(velocity * Time.deltaTime);
        }
    }

    public IEnumerator Shoot()
    {
        if (Input.GetButtonDown("Fire1") && mayShoot)
        {
            mayShoot = false;
            currentTime += step;
            Instantiate(bulletBullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f);
            mayShoot = true;
        }        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
            collision.gameObject.SetActive(false);
    }
}
