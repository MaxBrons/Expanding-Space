using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour
{


    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }


}
