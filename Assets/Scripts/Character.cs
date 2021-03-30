using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform pointForward;
    public float force = 1;
    public float jumpForce = 5;

    private Rigidbody rb;
    private Vector3 sideMove;
    private bool isJumpPressed = false;
    private float lastVelocityY = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        sideMove = Vector3.zero;
        //var a = pointForward.rotation.;
        //var b = Vector3.Cross(a, Vector3.forward);
        //Debug.Log(a + "------" + b);
        if (Input.GetKey("w")) sideMove += pointForward.forward;//sideMove += Vector3.forward; 
        if (Input.GetKey("a")) sideMove += -pointForward.right; 
        if (Input.GetKey("s")) sideMove += -pointForward.forward; 
        if (Input.GetKey("d")) sideMove += pointForward.right;
        isJumpPressed = Input.GetKey("space");//Input.GetKeyDown("space");
    }

    void FixedUpdate()
    {
        rb.AddForce(sideMove * force);
        if (isJumpPressed && Mathf.Abs(lastVelocityY - rb.velocity.y) < 0.001)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJumpPressed = false;
        }
    }
}
