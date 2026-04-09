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

    [SerializeField] private List<GameObject> aliensInLocation0;
    [SerializeField] private List<GameObject> aliensInLocation1;
    [SerializeField] private List<GameObject> aliensInLocation2;
    [SerializeField] private List<GameObject> aliensInLocation3;
    [SerializeField] private List<GameObject> aliensInLocation4;
    private Animator refreshAnimator;
    private GameObject slider;

    private GameObject current;
    private GetAlienName_Script sendNameScript;


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
        sendNameScript = GameObject.Find("Tablet").GetComponent<GetAlienName_Script>();

        levelLocationScript = GameObject.Find("Tablet").GetComponent<Level_Location_Script>();
        refreshAnimator = GameObject.Find("Refesh_TXT").GetComponent<Animator>();
        slider = GameObject.Find("LoveHeart_Slide");

        aliensInLocation0 = getAlienList.GetRange(0, 3);
        aliensInLocation1 = getAlienList.GetRange(3, 3);
        aliensInLocation2 = getAlienList.GetRange(6, 3);
        aliensInLocation3 = getAlienList.GetRange(9, 3);
        aliensInLocation4 = getAlienList.GetRange(12, 3);
        RandomiseDate();
    }

    public void CallingStart()
    {
        Start();
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
                if (aliensInLocation0.Count != 0)
                {
                    alienOnScreen = aliensInLocation0[Random.Range(0, aliensInLocation0.Count)]; //(choosing 1st date)
                    aliensInLocation0.Remove(alienOnScreen);
                }
                else 
                {
                    Debug.Log("0 left.");
                    RefreshTXTAnim();
                }
                break;
        case 1:
                if (aliensInLocation1.Count != 0)
                {
                    alienOnScreen = aliensInLocation1[Random.Range(0, aliensInLocation1.Count)]; //(choosing 2nd date)
                    aliensInLocation1.Remove(alienOnScreen);
                }
                else
                {
                    Debug.Log("0 left.");
                    RefreshTXTAnim();
                }
                break;
        case 2:

                if (aliensInLocation2.Count != 0)
                {
                    alienOnScreen = aliensInLocation2[Random.Range(0, aliensInLocation2.Count)]; //(choosing 3rd date)
                    aliensInLocation2.Remove(alienOnScreen);
                }
                else
                {
                    Debug.Log("0 left.");
                    RefreshTXTAnim();
                }
                break;
        case 3:
                if (aliensInLocation3.Count != 0)
                {
                    alienOnScreen = aliensInLocation3[Random.Range(0, aliensInLocation3.Count)]; //(choosing 4th date)
                    aliensInLocation3.Remove(alienOnScreen);
                }
                else
                {
                    Debug.Log("0 left.");
                    RefreshTXTAnim();
                }
                break;
        case 4:
                if (aliensInLocation4.Count != 0)
                {
                    alienOnScreen = aliensInLocation4[Random.Range(0, aliensInLocation4.Count)]; //(choosing 5th date)
                    aliensInLocation4.Remove(alienOnScreen);
                }
                else
                {
                    Debug.Log("0 left.");
                    RefreshTXTAnim();
                }
                break;
        case 5:
                Debug.Log("Case 5. Queen is next."); //then date the queen is next!
                break;
        case 6:
                Debug.Log("Case 6. Currently at the queen.");  //currently at the queen
                break;
        }
        Debug.Log(alienOnScreen.name);
        current = Instantiate(alienOnScreen, spawnLocation.transform);
        if (tabletAnimsScript.tabletOnScreenBool == true) 
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/Alien_Tablet_Spawning");
        }

        sendNameScript.setAlienName(alienOnScreen.name);

    }

    private void RefreshTXTAnim() 
    {
        refreshAnimator.ResetTrigger("Reset");
        refreshAnimator.SetTrigger("RefreshTXT_Trigger");
    }

    public void RefreshDatesButton() 
    {
        aliensInLocation0 = getAlienList.GetRange(0, 3);
        aliensInLocation1 = getAlienList.GetRange(3, 3);
        aliensInLocation2 = getAlienList.GetRange(6, 3);
        aliensInLocation3 = getAlienList.GetRange(9, 3);
        aliensInLocation4 = getAlienList.GetRange(12, 3);

        refreshAnimator.ResetTrigger("RefreshTXT_Trigger");
        refreshAnimator.SetTrigger("Reset");


        slider.SetActive(true);
        if (alienOnScreen != null) //if it DOES exist
        {
            alienOnScreen.SetActive(true);
        }
        RandomiseDate();
    }

    public void GoOnDateWith() 
    {
        listOfAliensScript.PlayerOnDateWith(alienOnScreen);
        Debug.Log("Going on date with " + alienOnScreen.name); //getting here
        tabletAnimsScript.MatchedAnimations();
    }
}
