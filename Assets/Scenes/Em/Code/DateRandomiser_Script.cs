using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DateRandomiser_Script : MonoBehaviour
{
    public List<GameObject> getAlienList;
    public GameObject alienOnScreen;
    private GameObject spawnLocation;
    private ListOfAliens_Script listOfAliensScript;
    private TabletAppearDissapear_Script tabletAnimsScript;

    private GameObject lastAlien;

    #region Location info
    private Level_Location_Script levelLocationScript;
    private int getLocation;
    #endregion

    private void Start() //replace to 'open dating app' function when tablet picked up. dont want to be able to choose new date whilst still on one
    {
        //if scene name=title, then find spawn loc, else, blank
        spawnLocation = GameObject.Find("AlienSpawn_Location");
        getAlienList = gameObject.GetComponent<ListOfAliens_Script>().singleAlienList;
        listOfAliensScript = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        tabletAnimsScript = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();

        levelLocationScript = GameObject.Find("Tablet").GetComponent<Level_Location_Script>();

        RandomiseDate();
    }

    public void RandomiseDate() 
    {
        //check if alien on screen, if no, add one, if yes, remove it THEN add one
        if (spawnLocation.transform.childCount > 0)
        {
            lastAlien = spawnLocation.transform.GetChild(0).gameObject;
            Destroy(lastAlien);
        }

        getLocation = levelLocationScript.currentLocation;

        switch (getLocation) 
        { 
        default:
                Debug.Log("Default case");
                break;
        case 0:
                Debug.Log("Case 0");
                alienOnScreen = getAlienList[Random.Range(0, 3)]; //(choosing 1st date)
                break;
        case 1:
                Debug.Log("Case 1");
                alienOnScreen = getAlienList[Random.Range(3, 6)]; //(choosing 2nd date)
                break;
        case 2:
                Debug.Log("Case 2");
                alienOnScreen = getAlienList[Random.Range(6, 9)]; //(choosing 3rd date)
                break;
        case 3:
                Debug.Log("Case 3");
                alienOnScreen = getAlienList[Random.Range(9, 12)]; //(choosing 4th date)
                break;
        case 4:
                Debug.Log("Case 4");
                alienOnScreen = getAlienList[Random.Range(12, 15)]; //(choosing 5th date)
                break;
        case 5:
                Debug.Log("Case 5. Queen is next."); //then date the queen is next!
                break;
        case 6:
                Debug.Log("Case 6. Currently at the queen.");  //currently at the queen
                break;
        }
        Debug.Log(alienOnScreen.name);

        Instantiate(alienOnScreen, spawnLocation.transform);
    }



    public void GoOnDateWith() 
    {
        listOfAliensScript.PlayerOnDateWith(alienOnScreen);
        Debug.Log("Going on date with " +alienOnScreen.name);


        tabletAnimsScript.SwapTabletVisibility();
        SceneManager.LoadScene("Date_Scene");
    }
}
