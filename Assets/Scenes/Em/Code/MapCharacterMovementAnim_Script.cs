using UnityEngine;

public class MapCharacterMovementAnim_Script : MonoBehaviour
{
    private GameObject character;
    private Animator characterAnimator;
    private int thisCurrentLocation;
    private Level_Location_Script levelLocationScript;

    private void Start()
    {
        character = GameObject.Find("Character");
        characterAnimator = character.GetComponent<Animator>();
        levelLocationScript = gameObject.GetComponent<Level_Location_Script>();
    }

    public void MapCharacterMovementAnims()
    {
        thisCurrentLocation = levelLocationScript.currentLocation;
        characterAnimator.SetInteger("Location_INT_Anim", thisCurrentLocation);
    }

}
