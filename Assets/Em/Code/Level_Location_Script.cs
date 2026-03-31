using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level_Location_Script : MonoBehaviour
{
    public int currentLocation;
    private TMP_Text currentDateText;
    [SerializeField] List<GameObject> locationList;

    private void Start()
    {
        currentDateText = GameObject.Find("CurrentMapText").GetComponent<TMP_Text>();
        currentLocation = 0;
    }

    public void MoveLocation() //call once date selected
    { 
        currentLocation = currentLocation +1;
        Debug.Log("Current location = " + currentLocation.ToString());
        currentDateText.text = "Current Date: " + currentLocation.ToString();
    }
}
