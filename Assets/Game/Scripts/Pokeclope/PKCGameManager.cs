using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class PKCGameManager : MonoBehaviour 
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public TextMeshProUGUI button1Text;
    public TextMeshProUGUI button2Text;
    public TextMeshProUGUI button3Text;
    public TextMeshProUGUI button4Text;

    public Animator animatorDialogue;
    public Animator animatorResponses;

    private int responseId ;

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

    private void Start()
    {
        StartCoroutine(LaunchGame());
    }
    private IEnumerator LaunchGame()
    {
        yield return new WaitForSeconds(1.0f);
        StartDialogue();
    }
    public void StartDialogue()
    {
        Debug.Log("Start of dialogue");
        
        responseId = UnityEngine.Random.Range(0, dialogues.Length);
        var dialogue = dialogues[responseId];
        nameText.text = dialogue.name;

        string sentence = dialogue.sentence;
        dialogueText.text = sentence;
        animatorDialogue.SetTrigger("Open");

        DisplayResponses();
    }

    public void DisplayResponses()
    {
        // potentiellement ajouter un shuffle des réponses 
        button1Text.text = dialogues[0].response ;
        button2Text.text = dialogues[1].response ;
        button3Text.text = dialogues[2].response ;
        button4Text.text = "Oui" ;

        animatorResponses.SetTrigger("Open");
        
    }
    public void CommitResponse(int buttonId)
    {
        if (buttonId == responseId)
        {
            Debug.Log("Correct response");
        } else
        {
            Debug.Log("Wrong response");
        }
        EndDialogue();
    }

    public void EndDialogue()
    {
        animatorResponses.SetTrigger("Close");
        animatorDialogue.SetTrigger("Close");
        Debug.Log("End of dialogue");
    }
}
