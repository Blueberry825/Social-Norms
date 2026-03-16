using UnityEngine;

public class ExitButton_Script : MonoBehaviour
{
    private Animator AreYouSure_Animator;

    private void Start()
    {
        AreYouSure_Animator = GameObject.Find("Exit_Area").GetComponent<Animator>();
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
