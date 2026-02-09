using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class InteractionSelector : MonoBehaviour
{
    public GameObject[] currentTransformPositions; //empty objects that act as coordinates for the interaction points to spawn in
    public GameObject[] Dialogues;
    public List<GameObject> optionTextBoxes;
    public GameObject textBox;

    public DialogueManager DialogueManager_scr;

    private ListOfAliens_Script listAlien_Script;
    private GameObject currentAlienDate;
    private int alienNumber;

    private void Start()
    {
        currentTransformPositions = GameObject.FindGameObjectsWithTag("transformLocation");

        listAlien_Script = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        currentAlienDate = listAlien_Script.currentDate;
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;
        Debug.Log("date scene alien number" + alienNumber);
        StartDialogue();
        SpawnLocationSelector();
    }


    private void Update()
    {

    }

    public void StartDialogue()
    {
        textBox.SetActive(true);
        Dialogues[alienNumber].SetActive(true);
    }

    public void SpawnLocationSelector() //add to id of each spawn point each time? so they spawn 1,2,3,4,5,6? 
    {
        optionTextBoxes[0].transform.position = currentTransformPositions[0].transform.position;
        optionTextBoxes[1].transform.position = currentTransformPositions[1].transform.position;
        optionTextBoxes[2].transform.position = currentTransformPositions[2].transform.position;
    }
}