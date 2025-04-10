using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour 
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    [System.Serializable]
    public struct Dialogue
    {
        [TextArea(3, 10)]
        public string sentence;
        [TextArea(3, 10)]
        public string response;
        public string name;

    }

    [SerializeField]
    public Dialogue[] dialogues;
    public void StartDialogue()
    {
        Debug.Log("Start of dialogue");
        animator.SetBool("IsOpen", true);
        var dialogue = dialogues[UnityEngine.Random.Range(0, dialogues.Length)];
        nameText.text = dialogue.name;

        string sentence = dialogue.sentence;

        DisplayNextSentence(sentence);
    }

    public void DisplayNextSentence(string sentence)
    {

        dialogueText.text = sentence;
        EndDialogue();
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        Debug.Log("End of dialogue");
    }
}
