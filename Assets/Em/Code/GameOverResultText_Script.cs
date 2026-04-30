using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverResultText_Script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dateDescriptionText;
    private GameObject alien;
    private int alienNumber;
    private string alienLocation;

    private Animator gameOverBackgroundAnim;
    private Animator endTextAnim_Good;
    private Animator endTextAnim_Bad;

    private UnityEngine.SceneManagement.Scene scene;


    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name != "Queen_Scene") 
        {
            dateDescriptionText = GameObject.Find("DateInfo").GetComponent<TextMeshProUGUI>();
        }

        gameOverBackgroundAnim = gameObject.GetComponent<Animator>();
    }

    private void GetLocation(int alienNum) 
    {
        switch (alienNum) 
        {
            case 0:
                alienLocation = "under the rocket";
                break;
            case 1:
                alienLocation = "by the rocket";
                break;
            case 2:
                alienLocation = "in the feilds by the rocket";
                break;
            case 3:
                alienLocation = "with the mountains in the distance";
                break;
            case 4:
                alienLocation = "inside the mountain's cave";
                break;
            case 5:
                alienLocation = "on top of the mountain";
                break;
            case 6:
                alienLocation = "in the bamboo forest";
                break;
            case 7:
                alienLocation = "in the swamp";
                break;
            case 8:
                alienLocation = "in the waterfall";
                break;
            case 9:
                alienLocation = "outside the cafe";
                break;
            case 10:
                alienLocation = "inside the cafe";
                break;
            case 11:
                alienLocation = "in the upstairs cafe";
                break;
            case 12:
                alienLocation = "at the beach";
                break;
            case 13:
                alienLocation = "at the ocean island";
                break;
            case 14:
                alienLocation = "by the misty water";
                break;
        }
    }

    public void GoodDate() 
    {
        gameOverBackgroundAnim = gameObject.GetComponent<Animator>();

        gameOverBackgroundAnim.SetBool("Background", false);
        Debug.Log("Good date");
        alien = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>().currentDate;
        alienNumber = alien.GetComponent<AliensDated_Script>().alienNumber;

        GetLocation(alienNumber);
        dateDescriptionText.text = "You and " + alien.name + " had a good date " + alienLocation + "."; 
    }


    public void BadDate() 
    {
        gameOverBackgroundAnim = gameObject.GetComponent<Animator>();


        gameOverBackgroundAnim.SetBool("Background", false);
        alien = GameObject.Find("AlienList_Save").GetComponent<ListOfAliens_Script>().currentDate;
        alienNumber = alien.GetComponent<AliensDated_Script>().alienNumber;

        GetLocation(alienNumber);
        dateDescriptionText.text = "You and " + alien.name + " had a bad date " + alienLocation + ".";
    }

    public void QueenGoodDate() 
    {
        gameOverBackgroundAnim = gameObject.GetComponent<Animator>();

        gameOverBackgroundAnim.SetBool("Background", true);

        endTextAnim_Good = GameObject.Find("EndText").GetComponent<Animator>();
        endTextAnim_Good.SetTrigger("EndText");
    }

    public void BadQueenGood() 
    {
        gameOverBackgroundAnim = gameObject.GetComponent<Animator>();

        gameOverBackgroundAnim.SetBool("Background", true);

        endTextAnim_Bad = GameObject.Find("EndText_Bad").GetComponent<Animator>();
        endTextAnim_Bad.SetTrigger("EndText");

    }
}
