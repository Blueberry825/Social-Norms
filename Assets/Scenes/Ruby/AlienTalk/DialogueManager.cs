using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public TMP_Text[] optionsTMP;

    public DialogueTrigger DialogueTrigger_scr;
    public InteractionSelector InteractionSelector_scr;

    public int round;
    public int meLines = 0; //each round of talking ?
    public int alienLines = 0;

    private List<string> actions;
    private List<string> options;
    private List<string> respones; 

    void Start()
    {
        DialogueTrigger_scr = InteractionSelector_scr.Dialogues[0].GetComponent<DialogueTrigger>();
        options = new List<string>();
        respones = new List<string>();
        actions = new List<string>();

        DialogueTrigger_scr.TriggerDialogueAction();
        DialogueTrigger_scr.TriggerDialogueOptions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OptionBubbles()//switch case 
    {
        switch(meLines)
        {
            case 0:
                //populate text lines 123
                for (int i = 0; i < InteractionSelector_scr.optionTextBoxes.Count; i++)
                {
                    InteractionSelector_scr.optionTextBoxes[i].GetComponentInChildren<TMP_Text>().text = options[i];
                }
                
                break;
            case 1:
                //
            break;


        }
    }

    public void ResponseBox()//switch case 
    {
        switch (alienLines)
        {
            case 0:
                //populate response lines 123

                break;
            case 1:
                
                break;


        }


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

        DisplayFirstSentence();
    }

    public void DisplayFirstSentence()
    {
        string sentence = actions[0];
        dialogueText.text = sentence;
    }

    //make function that can have option script pass info into to play a specific line

    public void EndDialogue()
    {
        Debug.Log("end convo");
    }
}