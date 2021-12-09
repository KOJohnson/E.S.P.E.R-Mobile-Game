using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODManager : MonoBehaviour
{
    public bool isInView;

    public GameObject highPoly;
    public GameObject lowPoly;

    private MeshRenderer highPolyMesh;
    private MeshRenderer lowPolyMesh;

    private void Awake()
    {
        highPolyMesh = highPoly.GetComponent<MeshRenderer>();
        lowPolyMesh = lowPoly.GetComponent<MeshRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInView)
        {
            highPolyMesh.enabled = false;
            lowPoly.SetActive(true);
        }
       
        else if (isInView)
        {
            lowPoly.SetActive(false);
            highPolyMesh.enabled = true;
        }
       
    }
}
