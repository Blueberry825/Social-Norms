using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    private List<string> sentences;

    void Start()
    {
        sentences = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("starting convo with " + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Add(sentence);
        }

        DisplayFirstSentence();
    }

    public void DisplayFirstSentence()
    {
        string sentence = sentences[0];
        dialogueText.text = sentence;
    }

    //make function that can have option script pass info into to play a specific line

    public void DisplayLine2()
    {
        string sentence = sentences[1];
        dialogueText.text = sentence;
    }

    public void DisplayLine3()
    {
        string sentence = sentences[2];
        dialogueText.text = sentence;
    }


    public void EndDialogue()
    {
        Debug.Log("end convo");
    }
}