using UnityEngine;

public class RefreshButton_Script : MonoBehaviour
{
    private DateRandomiser_Script dateScript;

    private void Start()
    {
        dateScript = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
    }

    public void clickedRefresh() 
    { 
        dateScript.RefreshDatesButton();
    }
}
