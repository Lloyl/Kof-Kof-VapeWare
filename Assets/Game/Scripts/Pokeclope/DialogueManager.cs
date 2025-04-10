using UnityEngine;
using System;
using System.Collections.Generic;
public class DialogueManager : MonoBehaviour 
{
    public Queue sentences;
    private void Start()
    {
        sentences = new Queue<string>();   
    }
    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Start of dialogue");
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);

    }

    public void EndDialogue()
    {
        Debug.Log("End of dialogue");
    }
}
