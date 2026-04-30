using UnityEngine;

public class QueenDialogueTrigger : MonoBehaviour
{
    public QueenDialogueHolder queenDialogue;

    public void TriggerDialogueOptions()
    {
        FindAnyObjectByType<QueenDialogue>().StartDialogueOptions(queenDialogue);
    }

    public void TriggerDialogueResponses()
    {
        FindAnyObjectByType<QueenDialogue>().StartDialogueRespones(queenDialogue);
    }

    public void TriggerDialogueAction()
    {
        FindAnyObjectByType<QueenDialogue>().StartDialogueActions(queenDialogue);
    }

    private void Start()
    {
        TriggerDialogueOptions();
        TriggerDialogueResponses();
        TriggerDialogueAction();
    }
}
