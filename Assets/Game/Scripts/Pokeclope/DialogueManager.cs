using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour 
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private void Start()
    {
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start of dialogue");

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
        Debug.Log("End of dialogue");
    }
}
