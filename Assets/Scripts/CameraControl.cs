using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform player;
    //public Vector3 dist;
    public float sensitivity = 1;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = player.position - dist;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
        //transform.position = player.position - dist;
    }
}
