using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class LoveMeter : MonoBehaviour
{
    public Slider loveMeter;
    private DialogueManager dialogueManager_scr;
    private ListOfAliens_Script ListOfAliens_Script_scr;
    private DateRandomiser_Script DateRandomiser_Script_scr;
    private int currentLocation;
    private Scene scene;

    public int result;
    public int decreaseAmount;
    public int increaseAmount;
    private int alienNumber;

    public GameObject currentAlien;
    private QueenDialogue queenDialogue_scr;

    public bool isLoveFull;

    public float loveAmount = 50f;
    public float decayAmount;
    public float decayTime;// how low between each decrease 
    public bool decaying;//if decreasing over time or not

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLocation = GameObject.Find("Tablet").GetComponent<Level_Location_Script>().currentLocation;
        ListOfAliens_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        DateRandomiser_Script_scr = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();

        isLoveFull = false;
        loveAmount = 50f;
        decaying = true;

        scene = SceneManager.GetActiveScene();
        if (scene.name != "Queen_Scene") 
        {
            dialogueManager_scr = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
           
        }
        currentAlien = ListOfAliens_Script_scr.currentDate;
        alienNumber = currentAlien.GetComponent<AliensDated_Script>().alienNumber;


        loveMeter.value = loveAmount;//set to default love amount

        DecaySpeed();//when level starts, set decay speed depending on current level
    }

    private void DecaySpeed()
    {
        switch (currentLocation)
        {
            case 0:// starting area
                break;
            case 1:  //first location  
                decayTime = 1.5f;
                decayAmount = 0.1f;
                break;

            case 2:
                decayTime = 1.5f;
                decayAmount = 0.2f;
                break;

            case 3:
                decayTime = 1.5f;
                decayAmount = 0.3f;
                break;

            case 4:
                decayTime = 1.5f;
                decayAmount = 0.3f;
                break;

            case 5:
                decayTime = 1.5f;
                decayAmount = 0.3f;
                break;

            case 6://queen?
                decayTime = 2f;
                decayAmount = 0.4f;
                break;

        }
    }


    // Update is called once per frame
    void Update() // decrease love amount each frame
    {

        loveMeter.value = loveAmount;

        if (loveAmount >= 70)
        {   
            isLoveFull = true;
        }
        else if (loveAmount <= 60)
        {
            isLoveFull = false;
        }


        if (decaying)
        {
            loveAmount -= decayAmount * (Time.deltaTime * decayTime);//?

            if (loveAmount <= 0)
            {
                //if queen
                scene = SceneManager.GetActiveScene();

                if (scene.name != "Queen_Scene")
                {
                    dialogueManager_scr.LoseState();

                }
                else if (scene.name == "Queen_Scene") 
                {
                    queenDialogue_scr = GameObject.Find("QueenDialogue").GetComponent<QueenDialogue>();
                    queenDialogue_scr.LoseState();
                }
                decaying = false;
            }
        }
    }


    public void RestartLevel()
    {
        ListOfAliens_Script_scr.DateReset(currentAlien);
        Time.timeScale = 1;
    }

    public void RestartQueenLevel() 
    {
        Start();
        SceneManager.LoadScene("Queen_Scene");
        Time.timeScale = 1;
    }

    public void LoveChange(int option)
    {
        switch(option)// optionID
        {
            case 0://love decrease
                loveAmount -= 9f;
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Dates/LoveMeter_Lose");
                break;

            case 1: //love neutral?

            break;

            case 2://love increase
                loveAmount += 18f;//TEMP 100 FOR TESTING
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Dates/LoveMeter_Gain");
                break;
            case 3://for queen only
                
                break;

            case 4://for queen only
                loveAmount -= 9f;
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Dates/LoveMeter_Lose");
                break;
        }
    }
}
