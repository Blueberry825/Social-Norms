using Unity.VisualScripting;
using UnityEngine;

public class EffectTiming : MonoBehaviour
{
    private DialogueManager dialogueManager_scr;
    private ListOfAliens_Script listAlien_Script_scr;
    private CRTEffectEditing CRTEffectEditing_scr;

    private int alienNumber;
    private int currentOptionElement;

    public GameObject[] giftList;

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

                if (currentOptionElement == 11)
                {
                    Instantiate(giftList[0], Vector3.zero, Quaternion.identity);
                }
                    break;
            case 1://if on alien 1
                if(currentOptionElement == 14)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 2:
                break;
            case 3:
                if (currentOptionElement == 9)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 4:
                if (currentOptionElement == 11)
                {
                    Instantiate(giftList[1], Vector3.zero, Quaternion.identity);
                }
                break;
            case 5:
                if (currentOptionElement == 14)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 6:
                if (currentOptionElement == 3)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 7:
                if (currentOptionElement == 14)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 8:
                if (currentOptionElement == 0)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 12)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 9:
                if (currentOptionElement == 9)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 12)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 10:
                if (currentOptionElement == 11)
                {
                    Instantiate(giftList[3], Vector3.zero, Quaternion.identity);
                }
                else if(currentOptionElement == 12)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 11:
                if (currentOptionElement == 5)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 14)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 20)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 12:
                if (currentOptionElement == 5)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 8)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 14)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 13:
                if (currentOptionElement == 0)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 9)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 4)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
            case 14:
                if (currentOptionElement == 0)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if (currentOptionElement == 9)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if(currentOptionElement == 13)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                else if (currentOptionElement == 16)//and player just clicked option element 14
                {
                    CRTEffectEditing_scr.ActivateEffect(0);//activate effect number 0(glitch)
                }
                break;
        }
    }

}

