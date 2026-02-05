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

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    //function called once dated
    public void PlayerOnDateWith(GameObject alien)
    {
        alien.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien = true;
        currentDate = alien;
        datedAlienList.Add(alien);
        singleAlienList.Remove(alien);

        //remove as current date each time
    }
}
