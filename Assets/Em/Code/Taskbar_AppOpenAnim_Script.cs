using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Taskbar_AppOpenAnim_Script : MonoBehaviour
{
    [SerializeField] private bool datingAppOpen_B;
    [SerializeField] private Animator datingAppOpenAnimator;

    //if scene name is date scene, play other anims
    private void Start()
    {
        datingAppOpenAnimator = gameObject.GetComponent<Animator>();
    }

    public void Taskbar_SwapDatingAppOpen()
    {
        if (SceneManager.GetActiveScene().name == "Date_Scene")
        {
            datingAppOpenAnimator.SetBool("DateScene", true);
        }
        else
        {
            datingAppOpenAnimator.SetBool("DateScene", false);
        }

        datingAppOpen_B = true;
        datingAppOpenAnimator.SetBool("open", datingAppOpen_B);

    }

    public void Taskbar_SwapDatingAppClose()
    {
        datingAppOpen_B = false;
        datingAppOpenAnimator.SetBool("open", datingAppOpen_B);
    }
}
