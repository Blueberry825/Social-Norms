using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_SceneChange_Script : MonoBehaviour
{
    private BackgroundMusic_Script bkMusic;
    private Scene currentScene;
    private settingsBackgroundAnim_Script settingsBGScript;

    private FullScreenToggle_Script screenToggle_Script;
    private TaskBar_DateOpenAnim_Script taskBar_DateOpenAnim;
    private Ambience_Script ambi_script;

    private void Start()
    {
        bkMusic = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        settingsBGScript = GameObject.Find("Settings_Background").GetComponent<settingsBackgroundAnim_Script>();
        ambi_script = GameObject.Find("BackgroundMusic_Holder").GetComponent<Ambience_Script>();

        sceneChanged_music();
    }

    public void sceneChanged_music()
    {
        currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        bkMusic.SceneChanged_AudioCheck(currentSceneName);

        settingsBGScript = GameObject.Find("Settings_Background").GetComponent<settingsBackgroundAnim_Script>();
        settingsBGScript.settingBackgroundCheck(currentScene);



        if (currentSceneName != "Opening_Scene")
        {
            screenToggle_Script = GameObject.Find("Settings_Area").GetComponent<FullScreenToggle_Script>();
            screenToggle_Script.initialise();
            bkMusic.bgmStartLoc_b = true;
            bkMusic.bgmStartLoc();

            taskBar_DateOpenAnim = GameObject.Find("Taskbar_DateOpen").GetComponent<TaskBar_DateOpenAnim_Script>();
            taskBar_DateOpenAnim.Taskbar_SwapDateOpenClose(currentScene);
        }
        else 
        {
            bkMusic.bgmStartLoc_b = false;
            bkMusic.bgmStartLoc();
        }

        if (currentSceneName == "Date_Scene")
        {
            ambi_script.startAmbience();
        }
        else 
        {
            ambi_script.stopAmbience();
        }
    }
}
