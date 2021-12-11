using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCol"))
        {
            Debug.Log("COLLIDED");
            Destroy(GameObject.FindWithTag("AmmoReplen"));
        }
    }
}