using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) 
    {
        Debug.Log(collision.name);
    }
}

