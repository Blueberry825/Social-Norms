using Microsoft.Unity.VisualStudio.Editor;
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
        Instantiate(currentBackground, gameObject.transform);
        GameObject spawnedAlien = Instantiate(currentAlienDate, gameObject.transform);

        spawnedAlien = GameObject.Find("Canvas").transform.GetChild(8).gameObject;//clone spawned in
        spawnedAlien.GetComponent<UnityEngine.UI.Image>().enabled = false;
        spawnedAlien.GetComponent<SpriteRenderer>().enabled = true;
        spawnedAlien.transform.localScale = new Vector3(1000, 1000);
    }
}
