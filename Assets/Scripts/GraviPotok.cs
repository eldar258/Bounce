using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraviPotok : MonoBehaviour
{
    public float force = 3;
    public float maxSpeed = 3;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        rb.velocity = Vector3.zero;
    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        rb.useGravity = false;

        Vector3 pointOnVectorZ = calculatePointOnVectorZ(rb);
        Vector3 vectorPointZ = pointOnVectorZ - rb.position;
        Vector3 forceToZ = Info.forceToReachVelocity(rb.velocity, vectorPointZ.normalized * maxSpeed, force);
        rb.AddForce(forceToZ * 3);

        Vector3 forceForward = Info.forceToReachVelocity(rb.velocity, transform.up * maxSpeed, float.MaxValue);
        rb.AddForce(forceForward);

       
        //rb.AddForce((vectorPointZ + vectorPotok).normalized * Force);
    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        rb.useGravity = true;
    }

    private Vector3 calculatePointOnVectorZ(Rigidbody rb)
    {
        Vector3 pointOnVectorZ = new Vector3(0, transform.InverseTransformPoint(rb.position).y, 0);
        pointOnVectorZ = transform.TransformPoint(pointOnVectorZ);
        return pointOnVectorZ;
    }
}
