using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskBar_DateOpenAnim_Script : MonoBehaviour
{
    [SerializeField] private bool dateOpen_B;
    [SerializeField] private Animator dateOpenAnimator;

    private void Start()
    {
        dateOpenAnimator = gameObject.GetComponent<Animator>();
    }

    public void Taskbar_SwapDateOpenClose(Scene currentScene) 
    {
        if (currentScene.name == "Date_Scene")
        {
            Taskbar_SwapDateOpen();
        }
        else 
        {
            Taskbar_SwapDateClose();
        }
    }

    private void Taskbar_SwapDateOpen()
    {
        dateOpen_B = true;
        dateOpenAnimator.SetBool("dateOpen", dateOpen_B);
    }

    private void Taskbar_SwapDateClose() 
    {
        dateOpen_B = false;
        dateOpenAnimator.SetBool("dateOpen", dateOpen_B);
    }
}
