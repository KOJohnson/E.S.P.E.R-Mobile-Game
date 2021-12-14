using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;

    private string objective;

    public int enemyKillCount;
    public int scoreCount;
    public bool hasKeyCard;
    public bool playerDead;

    public GameObject fadeIn;
    public GameObject fadeOut;

    public bool isObjectivePanel;

    [SerializeField] private GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;
    
    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private GameObject mainHUD;
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
        
        fadeIn.SetActive(true);
        objectivePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       ObjectiveTracker();

       if (playerDead)
       {
           ReloadScene();
       }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void OnPause()
    {
        if (!isPaused)
        {
            isPaused = true;
            //mainHUD.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            currentObjective.text = objective;
        }
        else
        {
            pauseMenu.SetActive(false);
            //mainHUD.SetActive(true);
            Time.timeScale = 1f;
            isPaused = false;
        }
        
    }
    
    // takes a string and uses it in the objective panel in the top left of the screen
    //notifying the player when ever they interact with certain game objects
    public void OpenObjectiveDisplay(string displayText)
    {
        if (!isObjectivePanel)
        {
            objectivePanel.SetActive(true);
            isObjectivePanel = true;
            objectiveText.text = displayText;
        }

        if (objectivePanel)
        {
            StartCoroutine(CloseObjectiveDisplay());
        }
    }

    public IEnumerator CloseObjectiveDisplay()
    {
        yield return new WaitForSeconds(uiFadeDelay);
        objectivePanel.SetActive(false);
        isObjectivePanel = false;
            
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
