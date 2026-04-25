using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class QueenDialogue : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private GameObject GameOver;
    private GameObject tablet;
    private GameObject armObject;

    private QueenDialogueTrigger QueenDialogueTrigger_scr;
    public QueenInteractionSelector QueenInteractionSelector_scr;
    private LoveMeter LoveMeter_scr;
    private Level_Location_Script Level_Location_Script_scr;
    private TabletAppearDissapear_Script TabletAppearDissapear_Script_scr;
    private DateRandomiser_Script DateRandomiser_Script_scr;

    public int round = 0;
    public int meLines = 0; //each round of talking ?
    public int alienLines = 0;
    private int maxlines;

    private int meLinesAdd3;

    public bool LinesEmpty;
    public bool retryLocation;

    private List<string> actions;
    private List<string> options;
    private List<string> respones;

    private void Awake()
    {
        armObject = GameObject.Find("Tentacle_0");
        armObject.SetActive(true);
    }

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name != "Queen_Scene")//TEMP
        {

            tablet = GameObject.Find("Tablet");
            Level_Location_Script_scr = tablet.GetComponent<Level_Location_Script>();
            TabletAppearDissapear_Script_scr = tablet.GetComponent<TabletAppearDissapear_Script>();
            DateRandomiser_Script_scr = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();

            StayOnLocation(false);
        }


        for (int i = 0; i < QueenInteractionSelector_scr.optionTextBoxes.Count; i++)
            QueenInteractionSelector_scr.optionTextBoxes[i].SetActive(false);//close option boxes

        GameOver = GameObject.Find("GameOver");
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", true);
        LoveMeter_scr = GameObject.Find("Canvas/LoveMeter").GetComponent<LoveMeter>();
        QueenDialogueTrigger_scr = QueenInteractionSelector_scr.QueenDialogue.GetComponent<QueenDialogueTrigger>();
        options = new List<string>();
        respones = new List<string>();
        actions = new List<string>();

        //Debug.Log("count of options: " + options.Count);
    }

    public void LoadTabletScreenTemp()
    {
        SceneManager.LoadScene("Title_Scene");
    }

    public void RestartDate()
    {
        SceneManager.LoadScene("Queen_Scene"); //adds alien again
    }

    public void LoseState()//put different info for winning and losing
    {
        armObject.SetActive(false);
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "Mission Failed";
        Level_Location_Script_scr.currentLocation--; 
        TabletAppearDissapear_Script_scr.isLevelOver = true;
        StayOnLocation(true);

    }//minus 1 to the location when losing to turn back progress of dating

    public void LoseState2()
    {
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "You";
        Level_Location_Script_scr.currentLocation--; 
        TabletAppearDissapear_Script_scr.isLevelOver = true;
        StayOnLocation(true);
    }

    public void StayOnLocation(bool value) 
    {
        retryLocation = value;
        DateRandomiser_Script_scr.getRetryLocation = retryLocation;
        //called to false if win
    }

    public void WinState()
    {
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "Mission Complete!";
        TabletAppearDissapear_Script_scr.isLevelOver = true;//when player starts level they have no longer won
        StayOnLocation(false);
    }//tell table that hasWon is true

    public void OptionBubbles()//switch case 
    {
        meLinesAdd3 = meLines * 5;
        maxlines = meLinesAdd3 + 5;
        Debug.Log("maxlines: " + maxlines + "count: " + options.Count);
       
        if (options.Count >= maxlines)
        {
            
            for (int i = 0; i < QueenInteractionSelector_scr.optionTextBoxes.Count; i++)
                QueenInteractionSelector_scr.optionTextBoxes[i].SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Dates/Interactions_Appear");

            for (int i = 0; i < QueenInteractionSelector_scr.optionTextBoxes.Count; i++)
                QueenInteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + meLinesAdd3];
        }
        else
        {
            Debug.Log("ran out of options");
            LoveMeter_scr.decaying = false;

            armObject.SetActive(false);

            if (LoveMeter_scr.isLoveFull)
            {
                WinState();
            }
            else
            {
                LoseState2();
            }            
        }
        meLines++;
    }

    public void HideObj(GameObject Obj)
    {
        Obj.SetActive(false);
    }


    public void ResponseBox(int selection)//switch case 
    {
        var alienLines5 = alienLines * 5;//(if round one option 4, response will be 4 etc)

        dialogueText.text = respones[selection + alienLines5];
        alienLines++;
    }

    public void StartDialogueRespones(QueenDialogueHolder dialogue)
    {
        respones.Clear();

        foreach (string sentence in dialogue.respones)
        {
            respones.Add(sentence);
        }

        print("responses length" + respones.Count);
    }

    public void StartDialogueOptions(QueenDialogueHolder dialogue)
    {
        options.Clear();

        foreach (string sentence in dialogue.options)
        {
            options.Add(sentence);
        }

        OptionBubbles();
    }

    public void StartDialogueActions(QueenDialogueHolder dialogue) //first spawn in opening dialogue and name
    {
        Debug.Log("starting convo with " + dialogue.name);

        nameText.text = dialogue.name;

        actions.Clear();

        foreach (string sentence in dialogue.actions)
        {
            actions.Add(sentence);
        }

        DisplayNextAction();

    }

    public void DisplayNextAction()
    {
        round++;
        Debug.Log("round: " + round);

        if (round <= actions.Count)
        {
            string sentence = actions[round - 1];
            dialogueText.text = sentence;
        }
        else
        {
            dialogueText.text = "i am getting tired of talking to you..";
        }
    }

    //make function that can have option script pass info into to play a specific line

    public void EndDialogue()
    {
        Debug.Log("end convo");
    }
}
