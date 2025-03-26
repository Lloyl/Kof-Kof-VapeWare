using System.Collections;
using Game.Scripts.Game_Manager;
using UnityEngine;

public class SCGameManager : MonoBehaviour, IGame
{
    public bool IsGameRunning { get; set; }

    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject lost;

    private void Start()
    {
        // AudioManager.Instance.PlayAudio(Audio.SC_AMBIANCE);
        
        // GameManager.Instance.CurrentGameManager = this;
        IsGameRunning = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        var win = other.gameObject.CompareTag(Constants.TAG_CLOPE);
        
        IsGameRunning = false;
        StartCoroutine(Result(win));
    }

    public void Win()
    {
        victory.SetActive(true);
    }

    public void Lost()
    {
        lost.SetActive(true);
    }
    
    public void GameOver()
    {
        StartCoroutine(Result(false));
    }
    
    private IEnumerator Result(bool win)
    {
        if (win) Win();
        else Lost();
        yield return new WaitForSeconds(1.5f); // animation time
        // GameManager.Instance.GameResult(win);
    }
}