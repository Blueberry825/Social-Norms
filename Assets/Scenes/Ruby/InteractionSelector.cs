using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class InteractionSelector : MonoBehaviour
{
    public GameObject[] spawnPurple, spawnGreen, spawnOrange; //empty objects that act as coordinates for the interaction points to spawn in
    public GameObject[] Dialogues;
    public GameObject interactionTarget;
    public GameObject textBox;
    public Transform canvasTransform; 

     private ListOfAliens_Script listAlien_Script;
     private GameObject currentAlienDate;
     private int alienNumber;

    private void Start()
    {
        canvasTransform = GameObject.Find("Canvas").transform;
        listAlien_Script = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        currentAlienDate = listAlien_Script.currentDate;
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;
        Debug.Log("date scene alien number" + alienNumber);
        StartDialogue();
    }

    //alien number 0-4 purple, 5-9 green, 10-14 orange

    private void Update()
    {
        
    }

    public void StartDialogue()
    {
        textBox.SetActive(true);
        Dialogues[alienNumber].SetActive(true);
    }

    public void SpawnLocationSelector()
    {     
        if (alienNumber < 5) // purple
        {
            for (int i = 0; i < spawnPurple.Length; i++)
            {
                Debug.Log(spawnPurple[i]);
                Instantiate(interactionTarget, (spawnPurple[i].transform.position), Quaternion.identity);  
            }     
        }
        else if (alienNumber > 4 && alienNumber < 10) // green
        {
            for (int i = 0; i < spawnGreen.Length; i++)
            {
                Debug.Log(spawnGreen[i]);
                Instantiate(interactionTarget, (spawnGreen[i].transform.position), Quaternion.identity);
            }
        }
        else if (alienNumber > 9) // orange
        {
            for (int i = 0; i < spawnOrange.Length; i++)
            {
                Debug.Log(spawnOrange[i]);
                Instantiate(interactionTarget, (spawnOrange[i].transform.position), Quaternion.identity);
            }
        }
    }
}