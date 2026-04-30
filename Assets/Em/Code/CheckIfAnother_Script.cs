using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckIfAnother_Script : MonoBehaviour
{
    private GameObject tabletCanvas;
    [SerializeField] private GameObject tabletPrefab;
    [SerializeField] private GameObject[] alienList;

    private void Start()
    {
        tabletCanvas = GameObject.Find("Tablet_Canvas(Clone)");

        if (tabletCanvas == null) 
        {
            Instantiate(tabletPrefab);
        }

        alienList = GameObject.FindGameObjectsWithTag("alienList"); 
        
        if (alienList != null) //if there is an alien list
        {
            int alienListLength = alienList.Length;

            if (alienListLength > 1) //if theres more than one alien list
            {
                //check length against another
                Destroy(alienList[1]);
            }
        }
    }
}
