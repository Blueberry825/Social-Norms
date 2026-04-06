using UnityEngine;

public class MusicUI_Map_Script : MonoBehaviour
{
    private FMOD.Studio.EventInstance mapMovement_Instance;
    private TabletAppearDissapear_Script tabletAnim_scr;

    private void Start()
    {
        mapMovement_Instance = FMODUnity.RuntimeManager.CreateInstance("event:/UI/Tablet/Map/Map_Movement");
        tabletAnim_scr = GameObject.Find("Tablet").GetComponent<TabletAppearDissapear_Script>();
    }

    public void mapOpen_AudioCue() 
    {
        if (tabletAnim_scr.tabletOnScreenBool == true) 
        {
            mapMovement_Instance.setParameterByName("MapMovement_Param", 0);
            mapMovement_Instance.start();
        }
    }

    public void mapClose_AudioCue()
    {
        if (tabletAnim_scr.tabletOnScreenBool == true)  //only plays audio if its on screen
        {
            mapMovement_Instance.setParameterByName("MapMovement_Param", 1);
            mapMovement_Instance.start();
        }
    }
}
