using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnimDecide_Script : MonoBehaviour
{
    private int thisCurrentLocation;
    private Level_Location_Script levelLocationScript;
    private Animator characterAnimator;

    private int currentAnimPlaying;
    private LoadScene_Script loadSceneScript;


    //if location bigger than anim, play next
    //else if location = anim, load scene

    private void Start()
    {
        levelLocationScript = GameObject.Find("Tablet").GetComponent<Level_Location_Script>();
        characterAnimator = gameObject.GetComponent<Animator>();
        loadSceneScript = gameObject.GetComponent<LoadScene_Script>();
    }


    private void CharacterAnimationDecision() //called in animator
    {
        thisCurrentLocation = levelLocationScript.currentLocation;

        Debug.Log("Location is " + thisCurrentLocation);
        //Debug.Log("Tag is " + characterAnimator

        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_1")) 
        {
            currentAnimPlaying = 1;
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_2"))
        {
            currentAnimPlaying = 2;
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_3"))
        {
            currentAnimPlaying = 3;
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_3"))
        {
            currentAnimPlaying = 3;
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_4"))
        {
            currentAnimPlaying = 4;
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_5"))
        {
            currentAnimPlaying = 5;
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_6"))
        {
            currentAnimPlaying = 6;
        }
        if (characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("CharacterAnim_7"))
        {
            currentAnimPlaying = 7;
        }


        if (currentAnimPlaying != 7)
        {
            if (thisCurrentLocation == currentAnimPlaying) //if current location is same number as the animation, load
            {
                loadSceneScript.SwapTabletVisability_();
                loadSceneScript.LoadDate();
            }
        }
        else
        {
            loadSceneScript.SwapTabletVisability_();
            SceneManager.LoadScene("Queen_Scene");
            print("loading queen scene");
        }
    }
}
