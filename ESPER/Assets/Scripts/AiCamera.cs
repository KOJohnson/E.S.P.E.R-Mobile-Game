using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCamera : MonoBehaviour
{
    
    [HideInInspector]public AiSensor sensor;
    private GameObject player;
    public bool playerSeen;
    // Start is called before the first frame update
    void Start()
    {
        sensor = GetComponent<AiSensor>();
        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) 
        {
            player = FindPlayer();
        }
    }
    
    private GameObject FindPlayer()
    {
        if (sensor.Objects.Count > 0)
        {
            playerSeen = true;
            return sensor.Objects[0];
        }
        return null;
    }
}
