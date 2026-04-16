using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SwipeLeftRight_Script : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private DateRandomiser_Script dateScript;
    private bool retry_Q;

    private FMOD.Studio.EventInstance sliderAudio;
    private bool hasAudioPlayed = false;

    private Animator tabletAnimator;

    private ListOfAliens_Script listAlienScript;
    private TabletAppearDissapear_Script TabletAppearDissapear_Script_scr;

    private void Start()
    {
        TabletAppearDissapear_Script_scr = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
        dateScript = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        sliderAudio = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Tablet/DatingApp/MoveSlider");

        tabletAnimator = GameObject.Find("Tablet").GetComponent<Animator>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (Mouse.current.leftButton.isPressed && hasAudioPlayed == false)
        {
            sliderAudio.start();
            hasAudioPlayed = true;
        }


        Vector3 position = transform.localPosition;
        transform.localPosition = new Vector3(Mathf.Clamp(position.x+eventData.delta.x, -200, 200), position.y, position.z);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        hasAudioPlayed = false;
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/Reset_Slider");

        Vector3 position = transform.localPosition;
        if (position.x < 200 && position.x > -200) 
        { 
            ResetPosition();
        }

        if (position.x == 200) 
        {
            SwipedRight();
        }

        if (position.x == -200)
        {
            SwipedLeft();
        }
    }

    public void SwipedLeft() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/SlideButton_Dismiss");
        dateScript.RandomiseDate();
        ResetPosition();
    }

    public void SwipedRight() 
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Tablet/DatingApp/SlideButton_Accept");
        TabletAppearDissapear_Script_scr.isLevelOver = false;//when player starts level they have no longer won
        dateScript = GameObject.Find("AlienList_Save").GetComponent<DateRandomiser_Script>();
        //check if retry, if retrying, load date, else, do that
        retry_Q = dateScript.getRetryLocation;

        if (retry_Q)
        {
            //SceneManager.LoadScene("Date_Scene");
            dateScript.RetryDateArea();
            //swap map
            //right alien?
        }
        else 
        {
            dateScript.GoOnDateWith();
        }
        ResetPosition();
    }

    private void ResetPosition() 
    {
        transform.localPosition = new Vector3(0, 0, 0);
    }

}
