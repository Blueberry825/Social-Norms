using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton_Script : MonoBehaviour
{
    private Animator AreYouSure_Animator;
    private Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Opening_Scene") 
        {
            AreYouSure_Animator = GameObject.Find("Exit_Area").GetComponent<Animator>();
        }
    }

    public void AreYouSure() 
    {
        AreYouSure_Animator.SetBool("Exit", true);
    }


    public void NotSure() 
    {
        AreYouSure_Animator.SetBool("Exit", false);
    }

    public void ExitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
