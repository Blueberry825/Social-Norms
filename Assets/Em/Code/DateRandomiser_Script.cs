using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class DateRandomiser_Script : MonoBehaviour
{
    public List<GameObject> getAlienList;
    public GameObject alienOnScreen;
    private GameObject spawnLocation;
    private ListOfAliens_Script listOfAliensScript;
    [SerializeField] private TabletAppearDissapear_Script tabletAnimsScript;
    private Animator characterAnim;

    private GameObject lastAlien;

    public GameObject queen;

    [SerializeField] private List<GameObject> aliensInLocation0;
    [SerializeField] private List<GameObject> aliensInLocation1;
    [SerializeField] private List<GameObject> aliensInLocation2;
    [SerializeField] private List<GameObject> aliensInLocation3;
    [SerializeField] private List<GameObject> aliensInLocation4;
    [SerializeField] private List<GameObject> aliensInLocation5;
    private Animator refreshAnimator;
    private GameObject slider;

    public bool retriedAlready;

    private GameObject current;
    private GetAlienName_Script sendNameScript;

    [TextArea(2, 5)]
    public string[] alienBios;


    public bool getRetryLocation;
    private TextAppearHideTabletStuff_Scrpt textAnimScr;

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
        characterAnim = GameObject.Find("Character").GetComponent<Animator>();

        aliensInLocation0 = getAlienList.GetRange(0, 3);
        aliensInLocation1 = getAlienList.GetRange(3, 2);
        aliensInLocation2 = getAlienList.GetRange(5, 3);
        aliensInLocation3 = getAlienList.GetRange(8, 2);
        aliensInLocation4 = getAlienList.GetRange(10, 3);
        aliensInLocation5 = getAlienList.GetRange(13, 2);

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
                if (aliensInLocation0.Count != 0)
                {
                    alienOnScreen = aliensInLocation0[Random.Range(0, aliensInLocation0.Count)]; //(choosing 1st date)
                    aliensInLocation0.Remove(alienOnScreen);
                }
                else 
                {
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
                    RefreshTXTAnim();
                }
                break;
        case 5:
                if (aliensInLocation5.Count != 0) 
                { 
                    alienOnScreen = aliensInLocation5[Random.Range(0, aliensInLocation5.Count)]; //choosing 6th date
                    aliensInLocation5.Remove(alienOnScreen);
                }
                else
                {
                    RefreshTXTAnim();
                }
                break;
        case 6:
                alienOnScreen = queen;
                Debug.Log("Case 6. Currently at the queen. location 7");  //queen time
                break;
        }
        //Debug.Log(alienOnScreen.name);
        current = Instantiate(alienOnScreen, spawnLocation.transform);
        if (tabletAnimsScript.tabletOnScreenBool == true) 
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/Alien_Tablet_Spawning");
        }

        sendNameScript.setAlienName(alienOnScreen.name);
        sendNameScript.setAlienBio(alienBios[alienOnScreen.GetComponent<AliensDated_Script>().alienNumber]);
    }

    private void RefreshTXTAnim() 
    {
        refreshAnimator.ResetTrigger("Reset");
        refreshAnimator.SetTrigger("RefreshTXT_Trigger");
    }

    public void RefreshDatesButton() 
    {
        getLocation = levelLocationScript.currentLocation;

        aliensInLocation0.Clear();
        aliensInLocation1.Clear();
        aliensInLocation2.Clear();
        aliensInLocation3.Clear();
        aliensInLocation4.Clear();
        aliensInLocation5.Clear();

        //get script from each alien that has their number

        foreach (GameObject GO in getAlienList) 
        { 
            AliensDated_Script alienInfoScript = GO.GetComponent<AliensDated_Script>();
            int number = alienInfoScript.alienNumber;
            int positionInList = getAlienList.IndexOf(GO);

            //switch case, if case = 1-3, alien in location = go


            switch (number) 
            {
                case 0:
                    aliensInLocation0.Add(getAlienList[positionInList]);
                    break;

                case 1:
                    aliensInLocation0.Add(getAlienList[positionInList]);
                    break;

                case 2:
                    aliensInLocation0.Add(getAlienList[positionInList]);
                    break;

                case 3:
                    aliensInLocation1.Add(getAlienList[positionInList]);
                    break;

                case 4:
                    aliensInLocation1.Add(getAlienList[positionInList]);
                    break;

                case 5:
                    aliensInLocation2.Add(getAlienList[positionInList]);
                    break;

                case 6:
                    aliensInLocation2.Add(getAlienList[positionInList]);
                    break;

                case 7:
                    aliensInLocation2.Add(getAlienList[positionInList]);
                    break;

                case 8:
                    aliensInLocation3.Add(getAlienList[positionInList]);
                    break;

                case 9:
                    aliensInLocation3.Add(getAlienList[positionInList]);
                    break;

                case 10:
                    aliensInLocation4.Add(getAlienList[positionInList]);
                    break;

                case 11:
                    aliensInLocation4.Add(getAlienList[positionInList]);
                    break;

                case 12:
                    aliensInLocation4.Add(getAlienList[positionInList]);
                    break;

                case 13:
                    aliensInLocation5.Add(getAlienList[positionInList]);
                    break;

                case 14:
                    aliensInLocation5.Add(getAlienList[positionInList]);
                    break;

            }
        }
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
        tabletAnimsScript.MatchedAnimations();
        tabletAnimsScript.isLevelOver = false;

        if (alienOnScreen.name != "Queen")
        {
            listOfAliensScript.PlayerOnDateWith(alienOnScreen);
            Debug.Log("Going on date with " + alienOnScreen.name);
        }
        else
        {
            listOfAliensScript.PlayerDateQueen();
        }

    }

    public void RetryDateArea() 
    {
        tabletAnimsScript.SwapTabletVisibility();
        textAnimScr = GameObject.Find("Matched_TXT").GetComponent<TextAppearHideTabletStuff_Scrpt>();
        textAnimScr.MatchedTextDone();
        listOfAliensScript.PlayerOnDateWith(alienOnScreen);
        SceneManager.LoadScene("Date_Scene");
    }

}
