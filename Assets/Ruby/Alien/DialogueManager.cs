using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private GameObject GameOver;
    private GameObject tablet;
    private GameObject armObject;
    private GameObject nextButton;

    private DialogueTrigger DialogueTrigger_scr;
    public InteractionSelector InteractionSelector_scr;
    private LoveMeter LoveMeter_scr;
    private Level_Location_Script Level_Location_Script_scr;
    private TabletAppearDissapear_Script TabletAppearDissapear_Script_scr;
    private DateRandomiser_Script DateRandomiser_Script_scr;
    private SaveAndLoad SaveAndLoad_scr;
    private GameOverResultText_Script gameoverResultText_scr;

    public int round = 0; //amount of action lines - 1
    public int meLines = 0; //each round of options?
    public int alienLines = 0; //amount of response rounds

    public int minResponseElement;
    public int minOptionElement;
    public int maxOptionElement;

    public bool LinesEmpty;
    public bool retryLocation;
    public bool canSkip;
    public bool tryingToSkip;

    private List<string> actions;
    private List<string> options;
    private List<string> respones;

    [SerializeField]private float typingSpeed = 0.08f;


    private void Awake()
    {
        armObject = GameObject.Find("Tentacle_0");
    }

    void Start()
    {
        //unhide mouse when date starts
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        tablet = GameObject.Find("Tablet");
        Level_Location_Script_scr = tablet.GetComponent<Level_Location_Script>();
        TabletAppearDissapear_Script_scr = tablet.GetComponent<TabletAppearDissapear_Script>();

        DateRandomiser_Script_scr = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        SaveAndLoad_scr = GameObject.Find("AlienList_Save").GetComponent<SaveAndLoad>();

        nextButton = GameObject.Find("Next");

        //get the current alien at the start of the scene// SCENE MUST START TO DATE EACH NEW ALIEN

        GameOver = GameObject.Find("GameOver");
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", true);
        LoveMeter_scr = GameObject.Find("Canvas/LoveMeter").GetComponent<LoveMeter>();
        DialogueTrigger_scr = InteractionSelector_scr.Dialogues[0].GetComponent<DialogueTrigger>();
        options = new List<string>();
        respones = new List<string>();
        actions = new List<string>();

        StayOnLocation(false);

       //Debug.Log("count of options: " + options.Count);

        for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
            InteractionSelector_scr.optionTextBoxes[i].SetActive(false);//close option boxes
    }

    public void StuffToDoAfterDate()//when going back to date screen after date
    {
        SaveAndLoad_scr.LoadLocationsAndAliens();
    }

    public void RestartDate()
    {
        SceneManager.LoadScene("Date_Scene"); //adds alien again
    }

    public void LoseState()//put different info for winning and losing
    {
        gameoverResultText_scr = GameObject.Find("GameOver").GetComponent<GameOverResultText_Script>();
        gameoverResultText_scr.BadDate();

        armObject.SetActive(false);
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/DateOver").GetComponent<TextMeshProUGUI>().text = "Date Failed";
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "Mission unsuccessful.";
        Level_Location_Script_scr.currentLocation--;
        TabletAppearDissapear_Script_scr.isLevelOver = true;
        StayOnLocation(true);

    }//minus 1 to the location when losing to turn back progress of dating

    public void LoseState2()
    {
        gameoverResultText_scr = GameObject.Find("GameOver").GetComponent<GameOverResultText_Script>();
        gameoverResultText_scr.BadDate();

        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/DateOver").GetComponent<TextMeshProUGUI>().text = "Date Failed";
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "You ran out of discussion, soldier.";
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
        gameoverResultText_scr = GameObject.Find("GameOver").GetComponent<GameOverResultText_Script>();
        gameoverResultText_scr.GoodDate();

        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/DateOver").GetComponent<TextMeshProUGUI>().text = "Date successful";
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "Mission Complete!";
        TabletAppearDissapear_Script_scr.isLevelOver = true;//when player starts level they have no longer won
        StayOnLocation(false);
    }//tell table that hasWon is true

    public void OptionBubbles()//switch case 
    {
        print("new options spawning");
        minOptionElement = meLines * 3;//lowest option element that we can be on
        maxOptionElement = minOptionElement + 3;//max option element that we can be on
        Debug.Log("maxlines: " + maxOptionElement + "count: " + options.Count);
       
        if (options.Count >= maxOptionElement)//if the full options list still bigger(/equal) than the current max option element
        {
            for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)//show option boxes
                InteractionSelector_scr.optionTextBoxes[i].SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Dates/Interactions_Appear");

            for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)//add text to option boxes
                InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + minOptionElement];//set text to next 3 option lines
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
        minResponseElement = alienLines * 3;//lowest response element we can be on

        string sentence = respones[selection + minResponseElement];
        canSkip = true;//can skip when typing starts
        StartCoroutine(DisplayResponseLine(sentence));

        alienLines++;
    }

    private IEnumerator DisplayResponseLine(string line)//type out reponse line
    {
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            //detect if player is trying to skip typing
            if (tryingToSkip)
            {
                dialogueText.text = line;
                canSkip = false;//cant skip until typing starts again
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        nextButton.SetActive(true);
    }

    public void StartDialogueRespones(Dialogue dialogue)
    {
        respones.Clear();

        foreach (string sentence in dialogue.respones)
        {
            respones.Add(sentence);
        }

    }

    public void StartDialogueOptions(Dialogue dialogue)
    {
        options.Clear();

        foreach (string sentence in dialogue.options)
        {
            options.Add(sentence);
        }
    }

    public void StartDialogueActions(Dialogue dialogue) //first spawn in opening dialogue and name
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

    private void Update()
    {
        Mouse mouse = Mouse.current;

        if (canSkip && mouse.leftButton.wasPressedThisFrame)//if bubbles are active
        {
            tryingToSkip = true;
        }
        else if (!canSkip)
        {
            tryingToSkip = false;
        }
    }

    public void DisplayNextAction()
    {
        nextButton.SetActive(false);
        round++;
        Debug.Log("round: " + round);

        if (round <= actions.Count)
        {
            string sentence = actions[round - 1];
            canSkip = true; //can skip once typing starts
            StartCoroutine(DisplayActionLine(sentence));
        }
        else
        {
            dialogueText.text = "i am getting tired of talking to you..";
            OptionBubbles();
        }
    }

    private IEnumerator DisplayActionLine(string line)//type out action line
    {
        dialogueText.text = "";

        foreach(char letter in line.ToCharArray())
        {
            //detect if player is trying to skip typing
            if (tryingToSkip)
            {
                dialogueText.text = line;
                canSkip = false;//cant skip after typing ends
                break;
            }

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        OptionBubbles();
    }

    //make function that can have option script pass info into to play a specific line

    public void EndDialogue()
    {
        Debug.Log("end convo");
    }
}