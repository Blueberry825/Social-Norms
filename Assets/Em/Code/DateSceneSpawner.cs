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

    public GameObject tempSpawnedAlien;

    private void Start()
    {
        listAlien_Script = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        BackgroundPicker();
    }

    private void BackgroundPicker()
    {
        currentAlienDate = listAlien_Script.currentDate;
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;
        currentBackground = backgroundList[alienNumber];
        GameObject bg = Instantiate(currentBackground, gameObject.transform);
        bg.transform.localScale = new Vector3(100, 100, 1);

        tempSpawnedAlien = Instantiate(currentAlienDate, gameObject.transform);
        tempSpawnedAlien.GetComponent<SpriteRenderer>().enabled = true;
        tempSpawnedAlien.GetComponent<UnityEngine.UI.Image>().enabled = false;
        tempSpawnedAlien.transform.localScale = new Vector3(1000, 1000);
        Debug.Log("changing spriterender");
    }

}