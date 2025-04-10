using UnityEngine;
using System.Collections;
public class DialogueManager : MonoBehaviour 
{
    public Queue sentences;
    private void Start()
    {
        sentences = new Queue();   
    }
}
