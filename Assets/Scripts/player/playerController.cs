using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    Vector2 velocity = Vector2.zero;
    Vector2 force;
    Transform player;

    public GameObject bulletBullet;
    public Text health_Amount;
    public Animator anim;
    public GameObject ExplosionAnim;

    public AudioManager audioManager, FXAudioManager;

    
    [SerializeField] private float maxVelocity = 5f;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float WaitToNextShot = 1f;
    [SerializeField] private float xMax = 0f, xMin = 0f, yMax = 0f, yMin = 0f;
    public GameObject FadeOut;

    public static float health = 3;
    public static float speed = 1f;
    public static float shield = 1;
    public static float damage = 1;

    private bool mayShoot = true;
    private bool MayMoveNow = false;

    void Start()
    {
        //Gets the player's transform
        player = GameObject.FindWithTag("Player").transform;
        health = 3;

        //Sets the UI element of the player's health to the variable health
        health_Amount.text = health.ToString();
    }

    void Update()
    {
        //Sets the rotation of the player to the position of the mouse
        if(Camera.main)
        {   
            //Gets the position off the player
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

            //Sets the rotation off the player to the mouse position
            float angle = AngleBetweenPoints(transform.position, mouseWorldPosition);
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));

            //Returns the angle between the player and the cursor
            float AngleBetweenPoints(Vector2 a, Vector2 b)
            {
                return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
            }
        }

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
            UI.feul -= Time.deltaTime / 10f;
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

        FXAudioManager.FXAudio(6);

        //If the player's damage is upgraded, the player will shoot 2 bullets instead of one
        if (damage > 1)
        {
            yield return new WaitForSeconds(1/3 * 2);
            //Spawns in the bullet
            Instantiate(bulletBullet, transform.position, transform.rotation);
            FXAudioManager.PlayAudio(6);
        }
            
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
                FXAudioManager.FXAudio(3);
                health--;
                health_Amount.text = health.ToString();
            }
            else
            {
                if (ExplosionAnim)
                    Instantiate(ExplosionAnim, transform.position, Quaternion.identity);
                audioManager.PlayAudio(5);
                Instantiate(FadeOut);
            }
        }
    }
}
