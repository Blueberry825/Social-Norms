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
    private GameObject armObject;

    public int result;

    public float loveAmount = 50f;
    public float decayAmount;
    public float decayTime;// how low between each decrease 
    public bool decaying;//if decreasing over time or not

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loveAmount = 50f;
        decaying = true;
        dialogueManager_scr = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        ListOfAliens_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        DateRandomiser_Script_scr = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        armObject = GameObject.Find("Tentacle_0");
        loveMeter.value = loveAmount;//set to default love amount
    }

    // Update is called once per frame
    void Update() // decrease love amount each frame
    {
        if (loveAmount > 100)
            loveAmount = 100;

        if (decaying)
        {
            loveMeter.value = loveAmount;
            loveAmount -= decayAmount * Time.deltaTime;

            armObject.SetActive(true);
            if (loveAmount <= 0)
            {
                dialogueManager_scr.LoseState();
                result = 0;
                decaying = false;
            }
            else if (loveAmount >= 100)
            {
                dialogueManager_scr.WinState();
                result = 1;
                decaying = false;
            }
        }
        else
        {
            armObject.SetActive(false);
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
        Time.timeScale = 1;
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
