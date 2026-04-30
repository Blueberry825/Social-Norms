using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    private InputSystem_Actions inputSystem;
    private InputAction menu;

    private BackgroundMusic_Script bgm_scr;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private bool isPaused;

    [SerializeField] private Animator startAreaAnimator;

    private void Start()
    {
        startAreaAnimator = GameObject.Find("StartArea").GetComponent<Animator>();
        bgm_scr = GameObject.Find("BackgroundMusic_Holder").GetComponent<BackgroundMusic_Script>();
    }

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

    public void pauseButton() 
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
        bgm_scr.PauseMenuBackgroundMusic();


        startAreaAnimator = GameObject.Find("StartArea").GetComponent<Animator>();
        startAreaAnimator.SetBool("OnScreen", false);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        isPaused = false;
        bgm_scr.PauseMenuBackgroundMusic();
    }
}
