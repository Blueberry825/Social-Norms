using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DateSceneSpawner : MonoBehaviour
{
    [SerializeField] private ListOfAliens_Script listAlien_Script;
    [SerializeField] private GameObject currentAlienDate;
    [SerializeField] private int alienNumber;

    [SerializeField] private GameObject blankBackground;
    [SerializeField] private List<GameObject> backgroundList;
    [SerializeField] private GameObject currentBackground;

    private Vector3 Scale, Location;

    private MouseTracking MouseTracking_scr;

    public GameObject tempSpawnedAlien;

    private void Start()
    {
        MouseTracking_scr = GameObject.Find("Target").GetComponent<MouseTracking>();
        listAlien_Script = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        BackgroundPicker();
    }

    private void BackgroundPicker()
    {
        currentAlienDate = listAlien_Script.currentDate;
        if (currentAlienDate.name != "Queen")
        {
            alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;
            currentBackground = backgroundList[alienNumber];
            GameObject bg = Instantiate(currentBackground, gameObject.transform);
            bg.transform.localScale = new Vector3(100, 100, 1);
        }

        CloneSizeAndLocation();
    }

    public void CloneSizeAndLocation()
    {
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;

        switch(alienNumber)//set individual location and scale for each 
        {
            case 0:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 1:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 2:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 3:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(60, 60);
                break;
            case 4:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 5:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 6:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 7:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 8:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 9:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 10:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 11:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 12:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 13:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
            case 14:
                Location = new Vector3(0, 0, 0);
                Scale = new Vector3(100, 100);
                break;
        }

        tempSpawnedAlien = Instantiate(currentAlienDate, Location, Quaternion.identity, gameObject.transform);//set location
        tempSpawnedAlien.GetComponent<SpriteRenderer>().enabled = true;
        tempSpawnedAlien.GetComponent<UnityEngine.UI.Image>().enabled = false;
        tempSpawnedAlien.transform.localScale = Scale;//set scale

        MouseTracking_scr.currentAlienClone = tempSpawnedAlien;//ensuring mouse has acess to clones animator

    }

}