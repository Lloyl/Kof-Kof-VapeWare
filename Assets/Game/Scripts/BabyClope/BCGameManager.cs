using System.Collections;
using UnityEngine;

public class BCGameManager : MonoBehaviour
{
    private static readonly int _WIN  = Animator.StringToHash("Win");
    private static readonly int _LOSE = Animator.StringToHash("Lose");

    [SerializeField] private Animator  playerAnimator;
    [SerializeField] private Animator  keeperAnimator;
    [SerializeField] private Animator  safeAnimator;
    [SerializeField] private Animator  pointsAnimator;

    private void Win()
    {
        AudioManager.Instance.PlayAudio(Audio.BC_WIN);
        playerAnimator.SetBool(_WIN, true);
        keeperAnimator.SetBool(_WIN, true);
        safeAnimator.SetBool(_WIN, true);
        pointsAnimator.SetBool(_WIN, true);
    }

    private void Lose()
    {
        AudioManager.Instance.PlayAudio(Audio.BC_LOSE);
        playerAnimator.SetBool(_LOSE, true);
        keeperAnimator.SetBool(_LOSE, true);
    }
    
    // quand la pièce touche le gardien ou le but
    public void OnCoinHit(bool win)
    {
        StartCoroutine(Result(win));
    }
    
    private IEnumerator Result(bool win)
    {
        if (win) Win();
        else Lose();
        yield return new WaitForSeconds(1.5f); // animation time
        if (win) GameManager.Instance.GameWin();
        else GameManager.Instance.GameLost();
    }
}