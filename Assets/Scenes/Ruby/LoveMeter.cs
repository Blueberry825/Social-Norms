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
    public DateRandomiser_Script DateRandomiser_Script_scr;

    public int result;

    public float loveAmount = 50f;
    public float decayAmount;
    public float decayTime;
    public bool decaying;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueManager_scr = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        ListOfAliens_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        DateRandomiser_Script_scr = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        loveMeter.value = loveAmount;//set to default love amount
    }

    // Update is called once per frame
    void Update() // decrease love amount each frame
    {
        loveMeter.value = loveAmount;
        loveAmount -= decayAmount * Time.deltaTime;

        if (loveAmount > 50)
            loveAmount = 50;

        if (loveAmount <= 0)
        {
            dialogueManager_scr.LoseState();
            result = 0;
        }
        else if (loveAmount >= 100) 
        {
            dialogueManager_scr.WinState();
            result = 1;
        }
    }

    public void AfterLevel()//anthing that changes based on result?
    {
        switch (result)// passed through from win or lose
        {
            case 0:
                
                break;

            case 1: 

                break;
        }
    }

    public void RestartLevel()
    {
        Start();
        SceneManager.LoadScene("Date_Scene");
        var currentAlien = DateRandomiser_Script_scr.alienOnScreen;
        ListOfAliens_Script_scr.PlayerOnDateWith(currentAlien);
    }

    public void LoveChange(int option)
    {
        switch(option)// optionID
        {
            case 0://love decrease
                loveAmount -= 15;
            break;

            case 1: //love neutral?

            break;

            case 2://love increase
                loveAmount += 15;
                break;

        }
    }
}
