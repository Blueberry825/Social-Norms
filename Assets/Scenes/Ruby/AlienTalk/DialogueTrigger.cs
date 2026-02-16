using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogueOptions()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogueOptions(dialogue);
    }

    public void TriggerDialogueResponses()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogueRespones(dialogue);
    }

    public void TriggerDialogueAction()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogueActions(dialogue);
    }

    private void Start()
    {
        TriggerDialogueOptions();
        TriggerDialogueResponses();
        TriggerDialogueAction();        
    }
}