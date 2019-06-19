using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject Player;

    void FixedUpdate()
    {
        Vector3 NewCameraPos = Player.transform.eulerAngles;
        transform.eulerAngles = NewCameraPos;
    }
}
