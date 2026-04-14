using System.Collections.Generic;
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
                foreach (GameObject GO in alienList) 
                {
                    ListOfAliens_Script alienScript = GO.GetComponent<ListOfAliens_Script>();
                    int singleAlien_L = alienScript.singleAlienList.Count;

                    if (singleAlien_L == 15) 
                    {
                        Destroy(GO);
                    }
                }
            }
        }



    }
}
