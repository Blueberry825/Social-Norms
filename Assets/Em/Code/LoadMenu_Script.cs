using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu_Script : MonoBehaviour
{
    public void loadScene() 
    {
        SceneManager.LoadScene("Opening_Scene");
    }
}
