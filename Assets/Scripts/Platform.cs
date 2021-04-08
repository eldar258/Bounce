using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float secForDestroy = 3;
    public float secForRedestroy = 3;

    private Rigidbody rb;
    private bool isFalling = false;
    private Vector3 startPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (isFalling)
        {
            isFalling = false;
            StartCoroutine(upliftTimer());
        } else
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFalling) StartCoroutine(fallTimer());
    }

    private IEnumerator fallTimer()
    {
        yield return new WaitForSeconds(secForDestroy);
        rb.isKinematic = false;
        isFalling = true;
    }

    private IEnumerator upliftTimer()
    {
        yield return new WaitForSeconds(secForRedestroy);
        rb.isKinematic = true;
    }
}
