using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviPotok : MonoBehaviour
{
    public float force = 10;
    public Transform centerMass;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.constraints = RigidbodyConstraints.None;
    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        rb.useGravity = false;
        Vector3 vecCenterMass = centerMass.position - rb.position;
        vecCenterMass.Normalize();
        other.GetComponent<Rigidbody>().AddForce(vecCenterMass * force);
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        rb.useGravity = true;
    }
}
