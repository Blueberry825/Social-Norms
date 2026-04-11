using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_SceneChange_Script : MonoBehaviour
{
    [SerializeField] private BackgroundMusic_Script bkMusic;
    private Scene currentScene;

    [SerializeField] private settingsBackgroundAnim_Script settingsBGScript;

    private void Start()
    {
        bkMusic = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        settingsBGScript = GameObject.Find("Settings_Background").GetComponent<settingsBackgroundAnim_Script>();

        sceneChanged_music();
    }

    public void sceneChanged_music()
    {
        currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        bkMusic.SceneChanged_AudioCheck(currentSceneName);

        settingsBGScript = GameObject.Find("Settings_Background").GetComponent<settingsBackgroundAnim_Script>();
        settingsBGScript.settingBackgroundCheck(currentScene);
    }
}
