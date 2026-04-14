using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsBackgroundAnim_Script : MonoBehaviour
{
    [SerializeField] private Animator settingBackgroundAnim;

    private void Start()
    {
        settingBackgroundAnim = gameObject.GetComponent<Animator>();
    }

    public void settingBackgroundCheck(Scene sceneCurrent) 
    {
        if (sceneCurrent.name == "Opening_Scene")
        {
            settingBackgroundAnim.SetBool("mainMenu", true);
        }

        if (sceneCurrent.name == "Date_Scene" || sceneCurrent.name == "TitleScene") 
        {
            settingBackgroundAnim.SetBool("mainMenu", false);
        }
    }
}
