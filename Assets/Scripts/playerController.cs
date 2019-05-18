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
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        float rotation = -Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);

        if (Input.GetKeyDown(KeyCode.W))
        {
            MayMoveNow = true;
            velocity = Vector2.zero;
        }
        else if (Input.GetKeyUp(KeyCode.W))
            MayMoveNow = false;

        if (MayMoveNow)
        {
            force = Vector2.up * acceleration * Time.deltaTime;
            velocity += force;
            velocity = Vector2.ClampMagnitude(velocity, maxVelocity);
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
