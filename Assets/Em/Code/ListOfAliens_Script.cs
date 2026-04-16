using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

//hold dialogue for each alien
public class ListOfAliens_Script : MonoBehaviour
{
    public List<GameObject> singleAlienList;
    public GameObject currentDate;
    public List<GameObject> datedAlienList;

    private Level_Location_Script levelLocationScript;
    private SaveAndLoad SaveAndLoad_scr;


    private void Start()
    {
        print($"saved location 0: {PlayerPrefs.GetInt("Location0")}");
        SaveAndLoad_scr = gameObject.GetComponent<SaveAndLoad>();
        levelLocationScript = GameObject.Find("Tablet").GetComponent<Level_Location_Script>();
    }

    //function called once dated
    public void PlayerOnDateWith(GameObject alien)
    {
        alien.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien = true;
        currentDate = alien;
        datedAlienList.Add(alien);
        singleAlienList.Remove(alien);

        SaveAndLoad_scr.SaveLocationAndAlien(currentDate.GetComponent<AliensDated_Script>().alienNumber);

        //remove as current date each time
        levelLocationScript.MoveLocation();
    }

    public void PlayerFailedDate_RemoveAlien() 
    {
        datedAlienList.Remove(currentDate);
        singleAlienList.Add(currentDate);
    }
}
