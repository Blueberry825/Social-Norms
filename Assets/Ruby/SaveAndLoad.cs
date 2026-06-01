using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField] public static SaveAndLoad instance;

    public GameObject[] alienThumbnailHolders;
    public Image testingImage;

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
        alienThumbnailHolders = GameObject.FindGameObjectsWithTag("Thumbnail");
        var locationHolders = GameObject.FindGameObjectsWithTag("holder");

        for (int i = 0; i < locationHolders.Length; i++)
        {
            locationHolders[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveLocationAndAlien(int currentdate)//get location and get alien 
    {
        currentLocation = Level_Location_Script_scr.currentLocation;

        if (currentLocation == 1)
        {
            PlayerPrefs.SetInt("Location1", currentdate);
            print("location 1 saved");
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
        currentLocation = Level_Location_Script_scr.currentLocation;

        if (listAlien_Script_scr.datedAlienList.Count > 0)//if player has dated anyone
        {
            switch (currentLocation - 1) //set the location images for each location here
            {
                case 0://if location 0(1), 
                    if (listAlien_Script_scr.datedAlienList.Count > 0)
                    {
                        alienThumbnailHolders[0].transform.GetComponent<Image>().sprite = listAlien_Script_scr.datedAlienList[0].gameObject.GetComponent<Image>().sprite;
                    }
                    break;
                case 1:
                    alienThumbnailHolders[1].transform.GetComponent<Image>().sprite = listAlien_Script_scr.datedAlienList[1].gameObject.GetComponent<Image>().sprite;
                    break;
                case 2:
                    alienThumbnailHolders[2].transform.GetComponent<Image>().sprite = listAlien_Script_scr.datedAlienList[2].gameObject.GetComponent<Image>().sprite;
                    break;
                case 3:
                    alienThumbnailHolders[3].transform.GetComponent<Image>().sprite = listAlien_Script_scr.datedAlienList[3].gameObject.GetComponent<Image>().sprite;
                    break;
                case 4:
                    alienThumbnailHolders[4].transform.GetComponent<Image>().sprite = listAlien_Script_scr.datedAlienList[4].gameObject.GetComponent<Image>().sprite;
                    break;
                case 5:
                    alienThumbnailHolders[5].transform.GetComponent<Image>().sprite = listAlien_Script_scr.datedAlienList[5].gameObject.GetComponent<Image>().sprite;
                    break;

            }
        }
    }
}

