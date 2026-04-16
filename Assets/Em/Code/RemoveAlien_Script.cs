using UnityEngine;

public class RemoveAlien_Script : MonoBehaviour
{
    private ListOfAliens_Script alienList;

    private void Start()
    {
        alienList = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();        
    }

    public void removeAlien() 
    { 
        alienList.PlayerFailedDate_RemoveAlien();
    }
}
