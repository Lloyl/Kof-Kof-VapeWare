using System.Collections;
using Game.Scripts.Game_Manager;
using UnityEngine;

public class SCGameManager : MonoBehaviour, IGame
{
    public bool IsGameRunning { get; set; }

    [SerializeField] private GameObject victory;
    [SerializeField] private GameObject lost;
    [SerializeField] private SCPlayer   player;
    [SerializeField] private GameObject clope;
    [SerializeField] private int        rangeSpawn;

    private void Start()
    {
        AudioManager.Instance.PlayAudio(Audio.SC_AMBIANCE);

        GameManager.Instance.CurrentGameManager = this;

        IsGameRunning = true;

        var x = clope.transform.position.x;
        x += Random.Range(0, rangeSpawn);

        clope.transform.position = new Vector3(x, clope.transform.position.y, clope.transform.position.z);
    }

    public void Win()
    {
        victory.SetActive(true);
        AudioManager.Instance.PlayAudio(Audio.SC_WIN);
    }

    public void Lost()
    {
        lost.SetActive(true);
        AudioManager.Instance.PlayAudio(Audio.SC_LOSE);
    }

    public void GameOver()
    {
        IsGameRunning = false;
        StartCoroutine(Result(!player.isHit));
    }

    private IEnumerator Result(bool win)
    {
        if (win) Win();
        else Lost();
        yield return new WaitForSeconds(1.5f); // animation time
        GameManager.Instance.GameResult(win);
    }
}