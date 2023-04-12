using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight_trigger : MonoBehaviour
{
    private float speed = 3f;

    //Moves this GameObject 2 units a second in the forward direction
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
            speed = speed * 0;
            Debug.Log("Враг вошел в триггер");
    }
    
    void OnTriggerStay(Collider other) {
        if (other.tag == "Enemy")

            Debug.Log("Находится в триггере");
    }
    void OnTriggerExit(Collider other) {
        if (other.tag == "Enemy")

            Debug.Log("Покинул триггер");
    }

}
