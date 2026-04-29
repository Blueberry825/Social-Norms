using System.Collections.Generic;
using UnityEngine;

public class QueenInteractionSelector : MonoBehaviour
{
    public GameObject[] currentTransformPositions; //empty objects that act as coordinates for the interaction points to spawn in
    public GameObject QueenDialogue;
    public List<GameObject> optionTextBoxes, currentBoxPos;
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

        foreach (GameObject go in currentTransformPositions)
        {
            currentBoxPos.Add(go);
        }

        for (int i = 0; i < optionTextBoxes.Count; i++) 
        {
            optionTextBoxes[i].transform.position = currentTransformPositions[i].transform.position;
        }
    }

    public void ResetLocationList()
    {
        currentBoxPos.Clear();
        foreach (GameObject go in currentTransformPositions)
        {
            currentBoxPos.Add(go);
        }
        print("This list has " + currentBoxPos.Count + " number of elements");
    }

    private List<GameObject> shuffleGOList(List<GameObject> inputList)
    {    //take any list of GameObjects and return it with Fischer-Yates shuffle
        int i = 0;
        int t = inputList.Count;
        int r = 0;
        GameObject p = null;
        List<GameObject> tempList = new List<GameObject>();
        tempList.AddRange(inputList);

        while (i < t)
        {
            r = Random.Range(i, tempList.Count);
            p = tempList[i];
            tempList[i] = tempList[r];
            tempList[r] = p;
            i++;
        }

        return tempList;
    }

    public void ShuffleLocationList()
    {
        List<GameObject> tempList = shuffleGOList(currentBoxPos);
        currentBoxPos = tempList;

        SpawnLocationSet();
    }

    public void SpawnLocationSet() //add to id of each spawn point each time? so they spawn 1,2,3,4,5,6? 
    {
        for (int i = 0; i < optionTextBoxes.Count; i++)
        {
            optionTextBoxes[i].transform.position = currentTransformPositions[i].transform.position;
        }
    }
}
