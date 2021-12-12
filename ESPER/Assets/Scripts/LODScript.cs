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
            var lodHit = lod.GetComponent<LODManager>();
            if (lodHit != null)
            {
                lodHit.isInView = true;
            }
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
        var lodNotInView = other.GetComponent<LODManager>();
        if (lodNotInView != null)
        {
            lodNotInView.isInView = false;
        }
        lodHitList.Remove(other.gameObject);
    }
}
