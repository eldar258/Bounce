using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public Transform Player;
    void Update()
    {
        transform.position = Player.position;
    }
}
