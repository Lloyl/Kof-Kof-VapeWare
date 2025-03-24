using System.Collections;
using Game.Scripts.Game_Manager;
using UnityEngine;

public class BCGameManager : MonoBehaviour, IGame
{
    public bool IsGameRunning { get; set; }
    
    private static readonly int _WIN  = Animator.StringToHash("Win");
    private static readonly int _LOSE = Animator.StringToHash("Lose");

    [SerializeField] private Animator keeperAnimator;
    [SerializeField] private Animator safeAnimator;

    private void Start()
    {
        GameManager.Instance.CurrentGameManager = this;
        IsGameRunning = true;
    }

    public void Win()
    {
        AudioManager.Instance.PlayAudio(Audio.BC_WIN);
        keeperAnimator.SetBool(_WIN, true);
        safeAnimator.SetBool(_WIN, true);
    }

    public void Lost()
    {
        AudioManager.Instance.PlayAudio(Audio.BC_LOSE);
        keeperAnimator.SetBool(_LOSE, true);
    }

    // quand la pièce touche le gardien ou le but
    public void OnCoinHit(bool win)
    {
        IsGameRunning = false;
        StartCoroutine(Result(win));
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
        GameManager.Instance.GameResult(win);
    }
}