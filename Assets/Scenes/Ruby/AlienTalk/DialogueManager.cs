using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    [SerializeField]public List<GameObject> optionTextBoxes;

    public int round = 0; //each round of talking ?

    private List<string> actions;
    private List<string> options;
    private List<string> respones; 

    void Start()
    {
        options = new List<string>();
        respones = new List<string>();
        actions = new List<string>();  

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogueRespones(Dialogue dialogue)
    {
        respones.Clear();

        foreach (string sentence in dialogue.respones)
        {
            respones.Add(sentence);
        }

        DisplayFirstSentence();
    }

    public void StartDialogueOptions(Dialogue dialogue)
    {
        options.Clear();

        foreach (string sentence in dialogue.options)
        {
            options.Add(sentence);
        }

        DisplayFirstSentence();
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