using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float secForDestroy = 3;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 3);
    }
}
