using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisabilityPropast : MonoBehaviour
{
    public Transform CharacterBody;
    public Transform teleportPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CharacterBody.transform.position.y < transform.position.y)
        {
            CharacterBody.transform.SetPositionAndRotation(teleportPoint.position, teleportPoint.rotation);
            CharacterBody.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
