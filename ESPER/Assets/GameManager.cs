using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    private string objective;

    public int enemyKillCount;
    public int scoreCount;
    public bool hasKeyCard;

    [SerializeField] private GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;
    
    [SerializeField]private GameObject pauseMenu;
    public TextMeshProUGUI currentObjective;
    public bool isPaused;
    
    [SerializeField] private float uiFadeDelay = 5.0f;

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
        
        objectivePanel.SetActive(false);
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       ObjectiveTracker();
    }

    public void OnPause()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            currentObjective.text = objective;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
        
    }
    
    public void OpenObjectiveDisplay(string displayText)
    {
        objectivePanel.SetActive(true);
        objectiveText.text = displayText;
        
    }

    public IEnumerator CloseObjectiveDisplay()
    {
        
        yield return new WaitForSeconds(uiFadeDelay);
        objectivePanel.SetActive(false);
    }

    private void ObjectiveTracker()
    {
        if (!hasKeyCard)
        {
            objective = "Find a computer to clone an elevator pass";
        }
        else
        {
            objective = "Use pass to gain access to elevator";
        }
    }
}
