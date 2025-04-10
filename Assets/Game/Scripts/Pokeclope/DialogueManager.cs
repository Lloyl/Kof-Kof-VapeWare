using UnityEngine;
using System;
public class DialogueManager : MonoBehaviour 
{
    private void Start()
    {
        
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start of dialogue");

        string sentence = dialogue.sentences[UnityEngine.Random.Range(0, dialogue.sentences.Length)];

        DisplayNextSentence(sentence);
    }

    public void DisplayNextSentence(string sentence)
    {

        Debug.Log(sentence);
        EndDialogue();
    }

    public void EndDialogue()
    {
        Debug.Log("End of dialogue");
    }
}
