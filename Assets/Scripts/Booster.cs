using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float force = 10;

    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(transform.up * force, ForceMode.Impulse);
    }
}
