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

    public int result;
    public int decreaseAmount;
    public int increaseAmount;
    private int alienNumber;

    public bool isLoveFull;

    public float loveAmount = 50f;
    public float decayAmount;
    public float decayTime;// how low between each decrease 
    public bool decaying;//if decreasing over time or not

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLocation = GameObject.Find("Tablet").GetComponent<Level_Location_Script>().currentLocation;

        isLoveFull = false;
        loveAmount = 50f;
        decaying = true;

        dialogueManager_scr = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        ListOfAliens_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        DateRandomiser_Script_scr = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        var currentAlien = ListOfAliens_Script_scr.currentDate;
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
                decayTime = 2f;
                decayAmount = 0.3f;
                break;

            case 2:
                decayTime = 2f;
                decayAmount = 0.3f;
                break;

            case 3:
                break;

            case 4:
                break;

            case 5:
                break;

            case 6://queen?
                break;

        }
    }

    public void WhichAlien()//how many options do they need to get correct to win?
    {
        switch (alienNumber)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
            case 15://queen?
                break;
        }
    }

    // Update is called once per frame
    void Update() // decrease love amount each frame
    {
        print(Time.deltaTime);

        loveMeter.value = loveAmount;

        if (loveAmount >= 80)
        {
            if (loveAmount >= 100)
            {
                loveAmount = 100;
                decaying = false;
            }      
            isLoveFull = true;
        }
        else if (loveAmount <= 70)
        {
            isLoveFull = false;
        }


        if (decaying)
        {
            loveAmount -= decayAmount * (Time.deltaTime * decayTime);//?

            if (loveAmount <= 0)
            {
                dialogueManager_scr.LoseState();
                decaying = false;
            }
        }

    }


    public void RestartLevel()
    {
        Start();
        SceneManager.LoadScene("Date_Scene");
        var currentAlien = DateRandomiser_Script_scr.alienOnScreen;
        ListOfAliens_Script_scr.PlayerOnDateWith(currentAlien);
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
                loveAmount += 27f;//TEMP 100 FOR TESTING
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Dates/LoveMeter_Gain");
                break;
            case 3://for queen only
                break;

            case 4://for queen only
                break;
        }
    }
}
