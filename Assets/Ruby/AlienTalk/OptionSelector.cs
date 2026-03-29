using UnityEngine;

public class OptionSelector : MonoBehaviour
{
    //make int that is the current line you want to play/pass though this script

    [SerializeField] public int interactionID;

    private DialogueManager dialogueManager_scr;
    private InteractionSelector interactionSelector_scr;

    //connect to interaction selector


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueManager_scr = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        interactionSelector_scr = GameObject.Find("GameManager").GetComponent<InteractionSelector>();
        Debug.Log(interactionID);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LinePlayer(int line)// add to interaction point, then each one have unique number?
    {

    }
}
