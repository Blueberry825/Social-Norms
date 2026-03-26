using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private InputSystem_Actions inputSystem;
    private InputAction menu;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isPaused;


    void Awake()
    {
       inputSystem = new InputSystem_Actions(); 
    }

    // Update is called once per frame
    private void OnEnable()
    {
        menu = inputSystem.Player.Escape;
        menu.Enable();

        menu.performed += Paused;
    }

    private void OnDisable()
    {
        menu.Disable();
    }

    void Paused(InputAction.CallbackContext context)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    public void ActivateMenu()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenu.SetActive(true);
        pauseMenu.transform.SetAsLastSibling();
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        isPaused = false;
    }
}
