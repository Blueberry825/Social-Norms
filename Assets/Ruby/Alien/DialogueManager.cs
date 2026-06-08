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
    public GameObject endButton;

    private DialogueTrigger DialogueTrigger_scr;
    public InteractionSelector InteractionSelector_scr;
    private LoveMeter LoveMeter_scr;
    private Level_Location_Script Level_Location_Script_scr;
    private TabletAppearDissapear_Script TabletAppearDissapear_Script_scr;
    private DateRandomiser_Script DateRandomiser_Script_scr;
    private GameOverResultText_Script gameoverResultText_scr;
    private ListOfAliens_Script ListOfAliens_Script_scr;
    private BackgroundMusic_Script bgm_scr;

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

    private FMOD.Studio.EventInstance textStreaming_instance;

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


        bgm_scr = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        tablet = GameObject.Find("Tablet");
        Level_Location_Script_scr = tablet.GetComponent<Level_Location_Script>();
        TabletAppearDissapear_Script_scr = tablet.GetComponent<TabletAppearDissapear_Script>();

        DateRandomiser_Script_scr = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        ListOfAliens_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();

        nextButton = GameObject.Find("Next");

        //get the current alien at the start of the scene// SCENE MUST START TO DATE EACH NEW ALIEN

        GameOver = GameObject.Find("GameOver");
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", true);
        LoveMeter_scr = GameObject.Find("Canvas/LoveMeter").GetComponent<LoveMeter>();
        DialogueTrigger_scr = InteractionSelector_scr.Dialogues[0].GetComponent<DialogueTrigger>();
        options = new List<string>();
        respones = new List<string>();
        actions = new List<string>();

        textStreaming_instance = FMODUnity.RuntimeManager.CreateInstance("event:/UI/TextStreaming");

        StayOnLocation(false);

       //Debug.Log("count of options: " + options.Count);

        for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
            InteractionSelector_scr.optionTextBoxes[i].SetActive(false);//close option boxes


    }

    public void StuffToDoAfterDate()//when going back to date screen after date
    {
        DateRandomiser_Script_scr.RandomiseDate();
    }

    public void RestartDate()
    {
        SceneManager.LoadScene("Date_Scene"); //adds alien again
    }

    public void LoseState()//put different info for winning and losing
    {
        ListOfAliens_Script_scr.PlayerFailedDate_RemoveAlien();

        gameoverResultText_scr = GameObject.Find("GameOver").GetComponent<GameOverResultText_Script>();
        gameoverResultText_scr.BadDate();

        armObject.SetActive(false);
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/DateOver").GetComponent<TextMeshProUGUI>().text = "Date Failed";
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "Mission unsuccessful.";

        if (Level_Location_Script_scr.currentLocation != 0)
        {
            Level_Location_Script_scr.currentLocation--;
            print(DateRandomiser_Script_scr.retriedAlready + "| location is now: " + Level_Location_Script_scr.currentLocation);
        }

        TabletAppearDissapear_Script_scr.isLevelOver = true;
        StayOnLocation(true);

    }//minus 1 to the location when losing to turn back progress of dating

    public void LoseState2()
    {
        ListOfAliens_Script_scr.PlayerFailedDate_RemoveAlien();

        gameoverResultText_scr = GameObject.Find("GameOver").GetComponent<GameOverResultText_Script>();
        gameoverResultText_scr.BadDate();

        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/DateOver").GetComponent<TextMeshProUGUI>().text = "Date Failed";
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "You ran out of discussion, soldier.";

        if (Level_Location_Script_scr.currentLocation != 0)
        {
            Level_Location_Script_scr.currentLocation--;
            print(DateRandomiser_Script_scr.retriedAlready + "| location is now: " + Level_Location_Script_scr.currentLocation);
        }

        TabletAppearDissapear_Script_scr.isLevelOver = true;
        StayOnLocation(true);
    }

    public void CallRestartGameFunction()
    {
        ListOfAliens_Script_scr.RestartGame();
    }

    public void StayOnLocation(bool value) 
    {
        retryLocation = value;
        DateRandomiser_Script_scr.getRetryLocation = retryLocation;
        //called to false if win
    }

    public void WinState()
    {
        ListOfAliens_Script_scr.PlayerWinDate_RemoveAlien();

        gameoverResultText_scr = GameObject.Find("GameOver").GetComponent<GameOverResultText_Script>();
        gameoverResultText_scr.GoodDate();

        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/DateOver").GetComponent<TextMeshProUGUI>().text = "Date successful";
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "Mission Complete!";
        TabletAppearDissapear_Script_scr.isLevelOver = true;//when player starts level they have no longer won
        DateRandomiser_Script_scr.retriedAlready = false;
       
        StayOnLocation(false);

    }//tell table that hasWon is true

    public void OptionBubbles()//switch case 
    {
        bgm_scr.TextStreamingSnapshot(false);

        minOptionElement = meLines * 3;//lowest option element that we can be on
        maxOptionElement = minOptionElement + 3;//max option element that we can be on
       
        if (options.Count >= maxOptionElement)//if the full options list still bigger(/equal) than the current max option element
        {
            for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)//show option boxes
                InteractionSelector_scr.optionTextBoxes[i].SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Dates/Interactions_Appear");

            for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)//add text to option boxes
                InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + minOptionElement];//set text to next 3 option lines

                InteractionSelector_scr.ShuffleLocationList();
        }
        else//end of date
        {
            LoveMeter_scr.decaying = false;

            armObject.SetActive(false);

            endButton.SetActive(true);
        }
        meLines++;
    }

    public void DirectToWinLose()
    {
        if (LoveMeter_scr.isLoveFull)
        {
            WinState();
        }
        else
        {
            LoseState2();
        }
    }


    public void HideObj(GameObject Obj)
    {
        Obj.SetActive(false);
    }


    public void ResponseBox(int selection)//switch case 
    {
        minResponseElement = alienLines * 3;//lowest response element we can be on

        string sentence = respones[selection + minResponseElement];

        StartCoroutine(WaitToSkip(sentence));

        alienLines++;
    }

    IEnumerator WaitToSkip(string line)
    {
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(.1f);

        StartCoroutine(DisplayResponseLine(line));
    }

    private IEnumerator DisplayResponseLine(string line)//type out reponse line
    {
        bgm_scr.TextStreamingSnapshot(true);
        canSkip = true;//can skip when typing starts
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
            textStreaming_instance.start();
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

        if (round <= actions.Count)
        {
            string sentence = actions[round - 1];
            StartCoroutine(DisplayActionLine(sentence));
        }
        else
        {
            OptionBubbles();
        }
    }

    private IEnumerator DisplayActionLine(string line)//type out action line
    {
        bgm_scr.TextStreamingSnapshot(true);
        canSkip = true; //can skip once typing starts
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
            textStreaming_instance.start();
            
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