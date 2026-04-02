using System.Collections.Generic;
using UnityEngine;

public class Level_Location_Script : MonoBehaviour
{
    public int currentLocation;
    [SerializeField] List<GameObject> locationList;

    private void Start()
    {
        currentLocation = 0;
    }

    public void MoveLocation() //call once date selected
    { 
        currentLocation = currentLocation +1;
        Debug.Log("Current location = " + currentLocation.ToString());
    }
}
