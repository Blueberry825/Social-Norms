using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField]public static SaveAndLoad instance;

    public Image[] alienThumbnailHolders;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private ListOfAliens_Script listAlien_Script_scr;

    private Level_Location_Script Level_Location_Script_scr;
    public int currentLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Level_Location_Script_scr = GameObject.Find("Tablet").GetComponent<Level_Location_Script>();
        listAlien_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
     
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
                    case 0://if location 0, 
                        alienThumbnailHolders[0].sprite = listAlien_Script_scr.datedAlienList[0].gameObject.GetComponent<Image>().sprite;
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

