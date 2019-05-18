using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    Vector3 vel = Vector3.zero;
    public float timeToSmooth = 0.3f;

    void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref vel.x, timeToSmooth), Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref vel.y, timeToSmooth), transform.position.z);
    }    
}
