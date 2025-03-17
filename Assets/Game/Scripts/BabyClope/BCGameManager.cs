using UnityEngine;

public class BCGameManager : MonoBehaviour
{
    private static readonly int _WIN  = Animator.StringToHash("Win");
    private static readonly int _LOSE = Animator.StringToHash("Lose");

    [SerializeField] private Animator  playerAnimator;
    [SerializeField] private Animator  keeperAnimator;
    [SerializeField] private Animator  safeAnimator;
    [SerializeField] private Animator  bgAnimator;
    [SerializeField] private Animator  pointsAnimator;
    [SerializeField] private BCCoinMovements coinMovements;

    public void Start()
    {
        coinMovements.OnCoinHitEvent += OnCoinHit;
    }

    private void Win()
    {
        GameManager.Instance.GameWin();

        AudioManager.Instance.PlayAudio("But Baby");
        playerAnimator.SetBool(_WIN, true);
        keeperAnimator.SetBool(_WIN, true);
        safeAnimator.SetBool(_WIN, true);
        bgAnimator.SetBool(_WIN, true);
        pointsAnimator.SetBool(_WIN, true);
    }

    private void Lose()
    {
        GameManager.Instance.GameLost();

        playerAnimator.SetBool(_LOSE, true);
        keeperAnimator.SetBool(_LOSE, true);
        bgAnimator.SetBool(_LOSE, true);
    }
    
    // quand la pièce touche le gardien ou le but
    private void OnCoinHit(bool win)
    {
        Debug.Log("Coin hit");
        if (win) Win();
        else Lose();
    }
}