using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_SceneChange_Script : MonoBehaviour
{
    private BackgroundMusic_Script bkMusic;
    private Scene currentScene;

    private void Start()
    {
        bkMusic = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
        sceneChanged_music();
    }

    public void sceneChanged_music() 
    {
        currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;

        bkMusic.SceneChanged_AudioCheck(currentSceneName);
        Debug.Log("scene change");
    }
}
