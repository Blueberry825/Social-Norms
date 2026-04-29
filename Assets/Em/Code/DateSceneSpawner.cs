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
            //bg.transform.localScale = new Vector3(100, 100, 1);
        }

        CloneSizeAndLocation();
    }

    public void CloneSizeAndLocation()
    {
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;

        print("alien number is: " + alienNumber);

        switch (alienNumber)
        {
            case 0:
                Location = new Vector3(0, 1, 0);
                Scale = new Vector3(55f, 55f);
                print("got to here");
                break;
            case 1:
                Location = new Vector3(0, 1, 0);
                Scale = new Vector3(50f, 50f);
                break;
            case 2:
                Location = new Vector3(0.15f, 0.18f, 0);
                Scale = new Vector3(70f, 70f);
                break;
            case 3:
                Location = new Vector3(0, -0.27f, 0);
                Scale = new Vector3(92.7f, 92.6f);
                break;
            case 4:
                Location = new Vector3(0.82f, 1.31f, 0);
                Scale = new Vector3(80f, 80f);
                break;
            case 5://has changed scale and location on animation 
                Location = new Vector3(-0.64f, 2.22f, 0);
                Scale = new Vector3(74f, 74f);
                break;
            case 6:
                Location = new Vector3(0, 0f, 0);
                Scale = new Vector3(92.7f, 92.6f);
                break;
            case 7:
                Location = new Vector3(0, 0.58f, 0);
                Scale = new Vector3(63.2f, 63f);
                break;
            case 8:
                Location = new Vector3(0.69f, 0.29f, 0);
                Scale = new Vector3(89f, 89f);
                break;
            case 9:
                Location = new Vector3(0.18f, 1.08f, 0);
                Scale = new Vector3(92f, 92f);
                break;
            case 10://raised the table height
                Location = new Vector3(0f, 0.77f, 0);
                Scale = new Vector3(92.7f, 92.6f);
                break;
            case 11:
                Location = new Vector3(0f, 0.67f, 0);
                Scale = new Vector3(54f, 54f);
                break;
            case 12:
                Location = new Vector3(-2.41f, 0.17f, 0);
                Scale = new Vector3(74f, 74f);
                break;
            case 13:
                Location = new Vector3(-1.18f, 1.69f, 0);
                Scale = new Vector3(69f, 69f);
                break;
            case 14:
                Location = new Vector3(0.15f, 1.11f, 0);
                Scale = new Vector3(68f, 68f);
                break;
        }

        tempSpawnedAlien = Instantiate(currentAlienDate, Location, Quaternion.identity, gameObject.transform);//set location
        tempSpawnedAlien.GetComponent<SpriteRenderer>().enabled = true;
        tempSpawnedAlien.GetComponent<UnityEngine.UI.Image>().enabled = false;
        tempSpawnedAlien.transform.localScale = Scale;//set scale

        MouseTracking_scr.currentAlienClone = tempSpawnedAlien;//ensuring mouse has acess to clones animator

        print("scale is currently" + tempSpawnedAlien.transform.localScale);
    }
}