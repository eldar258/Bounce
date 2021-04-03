using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform PlayerPoint;
    public float sensitivity = 1;
    public float dist = 0;

    private LayerMask maskDefault;

    void Start()
    {
        if (dist == 0) dist = transform.localPosition.magnitude;
        maskDefault = LayerMask.GetMask("Default");
    }
    void LateUpdate()
    {
        CameraTransform();
    }

    private void CameraTransform()
    {
        RaycastHit hit;
        if (Physics.Linecast(PlayerPoint.position + transform.localPosition.normalized, transform.position, out hit, maskDefault))
        {
            Camera.main.transform.position = hit.point;
        }
        else if (transform.localPosition.sqrMagnitude < dist * dist)
        {
            Camera.main.transform.position = transform.position;
        }
        transform.RotateAround(PlayerPoint.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
    }
}
