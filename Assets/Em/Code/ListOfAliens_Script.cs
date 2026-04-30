using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//hold dialogue for each alien
public class ListOfAliens_Script : MonoBehaviour
{
    public List<GameObject> singleAlienList;
    public GameObject currentDate;
    public List<GameObject> datedAlienList;

    private Level_Location_Script levelLocationScript;

    private Animator characterAnimator;

    private Scene scene;
    [SerializeField] private List<GameObject> singleAlienListTemplate;


    private void Start()
    {
        levelLocationScript = GameObject.Find("Tablet").GetComponent<Level_Location_Script>();
        singleAlienListTemplate = new List<GameObject>();

        foreach (GameObject go in singleAlienList) 
        { 
            singleAlienListTemplate.Add(go);
        }

    }

    //function called once dated
    public void PlayerOnDateWith(GameObject alien)
    {
        alien.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien = true;
        currentDate = alien;
        datedAlienList.Add(alien);
        singleAlienList.Remove(alien);

        levelLocationScript.MoveLocation();
    }

    public void DateReset(GameObject alien)
    {
        scene = SceneManager.GetActiveScene();
        alien.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien = true;
        currentDate = alien;
        datedAlienList.Add(alien);
        singleAlienList.Remove(alien);

        SceneManager.LoadScene(scene.name);
    }

    public void PlayerDateQueen()
    {
        //remove as current date each time
        levelLocationScript.MoveLocation();
    }

    public void PlayerFailedDate_RemoveAlien() 
    {
        if(currentDate.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien == true)//player has swiped right
        {
            datedAlienList.Remove(currentDate);
            singleAlienList.Add(currentDate);
            currentDate.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien = false;
        }
    }

    public void PlayerWinDate_RemoveAlien()
    {
        if (currentDate.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien == false)//player has swiped right
        {
            datedAlienList.Add(currentDate);
            singleAlienList.Remove(currentDate);
            currentDate.GetComponent<AliensDated_Script>().hasPlayerDatedThisAlien = true;
        }
    }

    public void RestartGame()//empty dated list, fill single list and set location to 0 
    {
        Time.timeScale = 1;
        levelLocationScript.currentLocation = 0;
        characterAnimator = GameObject.Find("Character").GetComponent<Animator>();
        characterAnimator.SetInteger("Location_INT_Anim", 0);
        //may need to add refresh dates

        SceneManager.LoadScene("Opening_Scene");

        datedAlienList.Clear();
        singleAlienList.Clear();

        foreach (GameObject go in singleAlienListTemplate)
        {
            singleAlienList.Add(go);
        }

        DateRandomiser_Script dateScript = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        dateScript.RefreshDatesButton();

        //foreach (GameObject alien in datedAlienList) 
        //{
        //    if (datedAlienList.Count > 0) 
        //    {
        //        //load new scene, remove as current date/refresh for area
        //        singleAlienList.Add(alien);
        //        datedAlienList.Clear();
        //        //maybe need to remove as current date too
        //    }

        //}


        //for (int i = 0; datedAlienList.Count > 0; i++)
        //{
        //    singleAlienList.Add(datedAlienList[i]);
        //    datedAlienList.Remove(datedAlienList[i]);
        //}

    }

}
