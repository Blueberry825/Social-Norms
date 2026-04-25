using UnityEngine;

public class EffectTiming : MonoBehaviour
{
    private DialogueManager dialogueManager_scr;
    private ListOfAliens_Script listAlien_Script_scr;
    private CRTEffectEditing CRTEffectEditing_scr;

    private int alienNumber;
    private int currentOptionElement;

    void Start()
    {
        CRTEffectEditing_scr = GameObject.Find("Main Camera").GetComponent<CRTEffectEditing>();
        listAlien_Script_scr = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>();
        var currentAlienDate = listAlien_Script_scr.currentDate;
        alienNumber = currentAlienDate.GetComponent<AliensDated_Script>().alienNumber;//get current alien number at start of date
        dialogueManager_scr = GetComponent<DialogueManager>();

    }

    public void WhichAlienCurrently(int selection)
    {
        currentOptionElement = dialogueManager_scr.minOptionElement + selection;//

        switch (alienNumber)//sort through the aliens 
        {
            case 0:
                break;
            case 1://if on alien 1
                if(currentOptionElement == 2)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 14:
                break;
        }
    }

}

