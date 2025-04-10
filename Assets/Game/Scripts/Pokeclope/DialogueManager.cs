using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour 
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;
    private void Start()
    {
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start of dialogue");
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        string sentence = dialogue.sentences[UnityEngine.Random.Range(0, dialogue.sentences.Length)];

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
