using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private GameObject GameOver;

    private DialogueTrigger DialogueTrigger_scr;
    public InteractionSelector InteractionSelector_scr;
    private LoveMeter LoveMeter_scr;

    public int round = 0;
    public int meLines = 0; //each round of talking ?
    public int alienLines = 0;
    private int maxlines;

    private int meLinesAdd3;

    public bool LinesEmpty;

    private List<string> actions;
    private List<string> options;
    private List<string> respones; 

    void Start()
    {
        GameOver = GameObject.Find("GameOver");
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", true);
        LoveMeter_scr = GameObject.Find("Canvas/LoveMeter").GetComponent<LoveMeter>();
        DialogueTrigger_scr = InteractionSelector_scr.Dialogues[0].GetComponent<DialogueTrigger>();
        options = new List<string>();
        respones = new List<string>();
        actions = new List<string>();

        Debug.Log("count of options: " + options.Count);

        for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
            InteractionSelector_scr.optionTextBoxes[i].SetActive(false);//close option boxes
    }

    public void LoadTabletScreenTemp()
    {
        SceneManager.LoadScene("Title_Scene");
    }


    public void LoseState()
    {
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "You lost";
    }

    public void LoseState2()
    {
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "You ran out of discussion";
    }

    public void WinState()
    {
        GameOver.GetComponent<Animator>().SetBool("IsGameGoing", false);
        GameObject.Find("GameOver/Result").GetComponentInChildren<TextMeshProUGUI>().text = "You won!";
    }

    public void OptionBubbles()//switch case 
    {
        meLinesAdd3 = meLines * 3;
        maxlines = meLinesAdd3 + 3;
        Debug.Log("maxlines: " + maxlines + "count: " + options.Count);
       
        if (options.Count >= maxlines)
        {
            
            for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                InteractionSelector_scr.optionTextBoxes[i].SetActive(true);
           
            switch (meLines)
            {
                case 0:
                    for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                        InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + meLinesAdd3];
                    break;
                case 1://figure out randomising placement
                    for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                        InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + meLinesAdd3];
                    break;
                case 2:
                    for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                        InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + meLinesAdd3];                     
                    break;
                case 3:
                    for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                        InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + meLinesAdd3];
                    break;
                case 4://figure out randomising placement
                    for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                        InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + meLinesAdd3];
                    break;
                case 5:
                    for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                        InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i + meLinesAdd3];
                    break;
            }       
        }
        else
        {
            Debug.Log("ran out of options");
            LoveMeter_scr.decaying = false;
            LoseState2();
        }
        meLines++;
    }

    public void HideObj(GameObject Obj)
    {
        Obj.SetActive(false);
    }


    public void ResponseBox(int selection)//switch case 
    {
 
        var alienLines3 = alienLines * 3;

        dialogueText.text = respones[selection + alienLines3];

        alienLines++;
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

        OptionBubbles();
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