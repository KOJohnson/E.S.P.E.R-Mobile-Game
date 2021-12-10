using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("COLLIDED");
            Destroy(GameObject.FindWithTag("AmmoReplen"));
        }
    }
}