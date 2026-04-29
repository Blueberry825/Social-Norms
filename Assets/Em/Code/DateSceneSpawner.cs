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

        switch (alienNumber)
        {
            case 0:
                Location = new Vector3(0, 0.58f, 0);
                Scale = new Vector3(0.55f, 0.55f);
                break;
            case 1:
                Location = new Vector3(0, 1, 0);
                Scale = new Vector3(0.5f, 0.5f);
                break;
            case 2:
                Location = new Vector3(0.15f, 0.18f, 0);
                Scale = new Vector3(0.7f, 0.7f);
                break;
            case 3:
                Location = new Vector3(0, -0.27f, 0);
                Scale = new Vector3(0.927f, 0.926f);
                break;
            case 4:
                Location = new Vector3(0.82f, 1.31f, 0);
                Scale = new Vector3(0.8f, 0.8f);
                break;
            case 5://has changed scale and location on animation 
                Location = new Vector3(-0.64f, 2.22f, 0);
                Scale = new Vector3(0.74f, 0.74f);
                break;
            case 6:
                Location = new Vector3(0, 0f, 0);
                Scale = new Vector3(0.927f, 0.926f);
                break;
            case 7:
                Location = new Vector3(0, 0.58f, 0);
                Scale = new Vector3(0.632f, 0.63f);
                break;
            case 8:
                Location = new Vector3(0.69f, 0.29f, 0);
                Scale = new Vector3(0.89f, 0.89f);
                break;
            case 9:
                Location = new Vector3(0.18f, 1.08f, 0);
                Scale = new Vector3(1f, 1f);
                break;
            case 10://raised the table height
                Location = new Vector3(0f, 0.77f, 0);
                Scale = new Vector3(0.927f, 0.926f);
                break;
            case 11:
                Location = new Vector3(0f, 0.67f, 0);
                Scale = new Vector3(0.54f, 0.54f);
                break;
            case 12:
                Location = new Vector3(-2.41f, 0.17f, 0);
                Scale = new Vector3(0.74f, 0.74f);
                break;
            case 13:
                Location = new Vector3(-1.18f, 1.69f, 0);
                Scale = new Vector3(0.69f, 0.69f);
                break;
            case 14:
                Location = new Vector3(0.15f, 1.11f, 0);
                Scale = new Vector3(0.68f, 0.68f);
                break;
        }

        tempSpawnedAlien = Instantiate(currentAlienDate, Location, Quaternion.identity);//set location
        tempSpawnedAlien.GetComponent<SpriteRenderer>().enabled = true;
        tempSpawnedAlien.GetComponent<UnityEngine.UI.Image>().enabled = false;
        tempSpawnedAlien.transform.localScale = Scale;//set scale

        MouseTracking_scr.currentAlienClone = tempSpawnedAlien;//ensuring mouse has acess to clones animator
    }
}