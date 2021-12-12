using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBinder : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            print("parent set");
            col.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
