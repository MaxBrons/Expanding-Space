using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 vel = Vector3.zero;
    [SerializeField] private float timeToSmooth = 0.3f;

    void FixedUpdate()
    {
        if (player)
        {
            //Closes the gap between the first and the second position over a set duration
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref vel.x, timeToSmooth);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref vel.y, timeToSmooth);

            //Changes the position of the object with the script on it to the position of the player
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}
