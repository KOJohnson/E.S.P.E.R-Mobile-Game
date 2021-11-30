using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    public int enemyKillCount;
    public int scoreCount;
    public bool hasKeyCard;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) //check if instance is null
        {
            instance = this; // assign instance to this instance of the class
        }
        else if (instance != this) //check if this instance has already been assigned elsewhere
        {
            Destroy(gameObject); //destroy manager if one already exists in the scene
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
