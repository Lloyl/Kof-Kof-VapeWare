using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public void TriggerDialogue()
    {
        FindFirstObjectByType<PKCGameManager>().StartDialogue();
    }
}
