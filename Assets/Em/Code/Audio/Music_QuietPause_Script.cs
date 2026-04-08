using UnityEngine;

public class Music_QuietPause_Script : MonoBehaviour
{
    private BackgroundMusic_Script music_Script;

    private void Start()
    {
        music_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
    }

    public void PauseMusic_Cue()
    {
        music_Script.PauseMenuBackgroundMusic();
    }
}
