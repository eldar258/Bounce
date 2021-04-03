using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float force = 10;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        rb.velocity = Vector3.ProjectOnPlane(rb.velocity, transform.up);
        rb.AddForce(transform.up * force, ForceMode.Impulse);
    }
}
