using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportPosition;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Transform>().position = teleportPosition.position;
    }
}
