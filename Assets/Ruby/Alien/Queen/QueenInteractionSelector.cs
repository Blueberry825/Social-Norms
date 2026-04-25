using System.Collections.Generic;
using UnityEngine;

public class QueenInteractionSelector : MonoBehaviour
{
    public GameObject[] currentTransformPositions; //empty objects that act as coordinates for the interaction points to spawn in
    public GameObject QueenDialogue;
    public List<GameObject> optionTextBoxes;
    public GameObject textBox;

    private void Start()
    {
        StartDialogue();
        SpawnLocationSelector();
    }


    private void Update()
    {

    }

    public void StartDialogue()
    {
        textBox.SetActive(true);
        QueenDialogue.SetActive(true);
    }

    public void SpawnLocationSelector() //add to id of each spawn point each time? so they spawn 1,2,3,4,5,6? 
    {
        currentTransformPositions = GameObject.FindGameObjectsWithTag("transformLocation");

        for (int i = 0; i < optionTextBoxes.Count; i++) 
        {
            optionTextBoxes[i].transform.position = currentTransformPositions[i].transform.position;
        }
    }
}
