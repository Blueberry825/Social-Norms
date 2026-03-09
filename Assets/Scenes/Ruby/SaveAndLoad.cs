using Unity.VisualScripting;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField]public static SaveAndLoad instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private ListOfAliens_Script listAlien_Script_scr;
    private AliensDated_Script AliensDated_Script_scr;
    private GameObject currentAlienDate;
    public int alienNumber;

    private Level_Location_Script Level_Location_Script_scr;
    public int currentLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Level_Location_Script_scr = GameObject.Find("Tablet").GetComponent<Level_Location_Script>();
        listAlien_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        AliensDated_Script_scr = currentAlienDate.GetComponent<AliensDated_Script>();
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;
        currentAlienDate = listAlien_Script_scr.currentDate;        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveLocationAndAlien(int currentdate)//get location and get alien 
    {
        currentLocation = Level_Location_Script_scr.currentLocation;

        if (currentLocation == 0)
        {
            PlayerPrefs.SetInt("Location0", currentdate);
        }
        else if (currentLocation == 1)
        {
            PlayerPrefs.SetInt("Location1", currentdate);
        }
        else if (currentLocation == 2)
        {
            PlayerPrefs.SetInt("Location2", currentdate);
        }
        else if (currentLocation == 3)
        {
            PlayerPrefs.SetInt("Location3", currentdate);
        }
        else if (currentLocation == 4)
        {
            PlayerPrefs.SetInt("Location4", currentdate);
        }
        else if (currentLocation == 5)
        {
            PlayerPrefs.SetInt("Location5", currentdate);
        }
    }

    public void LoadLocationsAndAliens()
    {
        if (listAlien_Script_scr.datedAlienList != null)//if player has dated anyone
        {
            for (int i = 0; i < listAlien_Script_scr.datedAlienList.Count; i++)//for the most amount of locations possible 
            {           
                switch (i) //set the location images for each location here
                {     
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;

                }
            }
        }
    }
}

