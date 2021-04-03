using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform pointForward;
    public float force = 1;
    public float jumpForce = 8;
    public float maxSpeed = 15;

    private Rigidbody rb;
    private Vector3 sideMove;
    private bool isJumpPressed = false;
    private bool isInBooster = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        sideMove = Vector3.zero;
        if (Input.GetKey("w")) sideMove += pointForward.forward;
        if (Input.GetKey("a")) sideMove += -pointForward.right; 
        if (Input.GetKey("s")) sideMove += -pointForward.forward; 
        if (Input.GetKey("d")) sideMove += pointForward.right;
        isJumpPressed = Input.GetKey("space");
    }

    void FixedUpdate()
    {
        if (isPossibleToJump() && !isInBooster)
        {
            rb.AddForce(pointForward.up * jumpForce, ForceMode.Impulse);
            isJumpPressed = false;
        }
        else isInBooster = false;
        if (sideMove != Vector3.zero)
        {
            Vector3 vectorForceResult = Info.forceToReachVelocity(rb.velocity, sideMove.normalized * maxSpeed, force);
            rb.AddForce(vectorForceResult);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInBooster = other.CompareTag("Booster");
    }

    private bool isPossibleToJump()
    {
        return isJumpPressed && Mathf.Abs(rb.velocity.y) < 0.001f;
    }
}
