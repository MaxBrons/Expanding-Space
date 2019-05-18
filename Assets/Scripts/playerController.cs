using UnityEngine;

public class playerController : MonoBehaviour
{
    Vector2 velocity = Vector2.zero;
    Vector2 force;
    Transform player;
    public float speed = 3;
    public float maxVelocity = 5f;
    public float rotationSpeed = 20f;
    public float acceleration = 1f;
    bool MayMoveNow = false;

    void Start()
    {
        //Hides the cursor and lockes the cursor to the bounderies of the gamescreen
        Cursor.lockState = CursorLockMode.Locked;

        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Movement();
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

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //bullet instantiation;
        }
    }
}
