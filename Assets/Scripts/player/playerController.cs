using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public static playerController instance;

    Vector2 velocity = Vector2.zero;
    Vector2 force;
    Transform player;

    public GameObject bulletBullet;
    public Text health_Amount;
    public Animator anim;

    
    [SerializeField] private float maxVelocity = 5f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float WaitToNextShot = 1f;
    [SerializeField] private float xMax = 0f, xMin = 0f, yMax = 0f, yMin = 0f;
    [SerializeField] private GameObject Upgrades;

    public static float health = 3;
    public static float speed = 1f;

    private bool mayShoot = true;
    private bool MayMoveNow = false;

    void Start()
    {
        //Hides the cursor and lockes the cursor to the bounderies of the gamescreen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Gets the player's transform
        player = GameObject.FindWithTag("Player").transform;

        //Sets the UI element of the player's health to the variable health
        health_Amount.text = health.ToString();
    }

    void Update()
    {
        //Sets the rotation of the player to the x position of the mouse
        float rotation = -Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        //If the W key is pressed trigger the player's movement
        //You stop the trigger when the W key is released
        if (Input.GetKeyDown(KeyCode.W))
        {
            MayMoveNow = true;
            anim.SetTrigger("Move");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetTrigger("Stop");
            MayMoveNow = false;
            velocity = Vector2.zero; //Resets the velocity of the player
        }

        if (MayMoveNow)
        {
            //Player moves forward when the W key is pressed
            force = Vector2.up * speed * acceleration * Time.deltaTime;
            velocity += force;

            //Increases the movement speed over time
            velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
            transform.Translate(velocity * Time.deltaTime);

            //Lowers the amount of feul when moving
            UI.feul -= Time.deltaTime / 5;
        }

        //You shoot when the left mouse button is pressed
        if (Input.GetButtonDown("Fire1") && mayShoot)
            StartCoroutine(Shoot());

        //Forces the player to stay in a surtant play area
        transform.position = new Vector2(
        Mathf.Clamp(transform.position.x, xMin, xMax),
        Mathf.Clamp(transform.position.y, yMin, yMax));
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
            if (health > 1)
            {
                health--;
                health_Amount.text = health.ToString();
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(3);
            }
        }
    }

    

}
