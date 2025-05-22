using System.Collections;
using Game.Scripts.Game_Manager;
using UnityEngine;
public class BTDGameManager : MonoBehaviour, IGame
{
    public bool IsGameRunning {get ;set;}

    [SerializeField] public BTDLaveDents laveDents;
    public void GameOver()
    {
        IsGameRunning = false;
        StartCoroutine(Result(laveDents.hasWin));
    }

    public void Lost()
    {
        throw new System.NotImplementedException();
    }

    public void Win()
    {
        throw new System.NotImplementedException();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //GameManager.Instance.CurrentGameManager = this;
        IsGameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Result(bool win)
    {
        yield return new WaitForSeconds(1.5f); // animation time
        GameManager.Instance.GameResult(win);
    }
}
