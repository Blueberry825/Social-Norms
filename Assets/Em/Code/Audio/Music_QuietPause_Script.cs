using UnityEngine;

public class Music_QuietPause_Script : MonoBehaviour
{
    private BackgroundMusic_Script music_Script;
    [SerializeField] private bool tabletOpenMusicQuiet;

    private void Start()
    {
        music_Script = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
    }

    public void PauseMusic_Cue() //called in animator when tablet opened and closed
    {
        tabletOpenMusicQuiet = !tabletOpenMusicQuiet;
        music_Script.TextStreamingSnapshot(tabletOpenMusicQuiet);
    }
}
