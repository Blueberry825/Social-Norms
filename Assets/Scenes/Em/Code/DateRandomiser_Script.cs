using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DateRandomiser_Script : MonoBehaviour
{
    public List<GameObject> getAlienList;
    public GameObject alienOnScreen;
    [SerializeField] private GameObject spawnLocation;
    private ListOfAliens_Script listOfAliensScript;

    private GameObject lastAlien;

    private void Start() //replace to 'open dating app' function when tablet picked up 
    {
        ////if scene name=title, then find spawn loc, else, blank
        spawnLocation = GameObject.Find("AlienSpawn_Location");
        getAlienList = gameObject.GetComponent<ListOfAliens_Script>().singleAlienList;
        listOfAliensScript = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();

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

        alienOnScreen = getAlienList[Random.Range(0, getAlienList.Count)];
        Debug.Log(alienOnScreen.name);

        Instantiate(alienOnScreen, spawnLocation.transform);
    }

    public void GoOnDateWith() 
    {
        listOfAliensScript.PlayerOnDateWith(alienOnScreen);
        Debug.Log("Going on date with " +alienOnScreen.name);
        SceneManager.LoadScene("Date_Scene");
    }
}
