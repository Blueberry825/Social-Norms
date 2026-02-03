using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DateSceneSpawner : MonoBehaviour
{
    [SerializeField] private ListOfAliens_Script listAlien_Script;
    [SerializeField] private GameObject currentAlienDate;
    [SerializeField] private int alienNumber;

    [SerializeField] private GameObject blankBackground; //eventually, instead of instatiating, find and replace image
    [SerializeField] private List<GameObject> backgroundList;
    [SerializeField] private GameObject currentBackground;

    private void Start()
    {
        listAlien_Script = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        currentAlienDate = listAlien_Script.currentDate;
        BackgroundPicker();
    }

    private void BackgroundPicker() 
    {
        //needs to be before alien gets removed from the list
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;
        currentBackground = backgroundList[alienNumber];
        Debug.Log("Current background is " +currentBackground.name);
        //Instantiate(currentBackground, gameObject.transform);
        Instantiate(currentAlienDate, gameObject.transform);
    }
}
