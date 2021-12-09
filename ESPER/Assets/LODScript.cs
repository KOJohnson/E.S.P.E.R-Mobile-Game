using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LODScript : MonoBehaviour
{
    public List<GameObject> lodHitList;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject lod in lodHitList)
        {
            Debug.DrawLine(transform.position, lod.transform.position, Color.red);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LOD"))
        {
            lodHitList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        lodHitList.Remove(other.gameObject);
    }
}
