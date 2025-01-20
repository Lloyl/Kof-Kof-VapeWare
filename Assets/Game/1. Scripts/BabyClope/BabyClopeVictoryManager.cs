using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyClopeVictoryManager : MonoBehaviour
{
    private static readonly  int       _WIN  = Animator.StringToHash("Win");
    private static readonly  int       _LOSE = Animator.StringToHash("Lose");
    
    [SerializeField] private Animator  playerAnimator;
    [SerializeField] private Animator  keeperAnimator;
    [SerializeField] private Animator  safeAnimator;
    [SerializeField] private Animator  bgAnimator;
    [SerializeField] private Animator  pointsAnimator;
    [SerializeField] private Rigidbody coinBody;

    public void Win()
    {
        AudioManager.Instance.PlayAudio("But Baby");
        GameStats.Instance.Win = true;
        playerAnimator.SetBool(_WIN, true);
        keeperAnimator.SetBool(_WIN, true);
        safeAnimator.SetBool(_WIN, true);
        bgAnimator.SetBool(_WIN, true );
        pointsAnimator.SetBool(_WIN, true);
    }

    public void Lose()
    {
        playerAnimator.SetBool(_LOSE, true);
        keeperAnimator.SetBool(_LOSE, true);
        bgAnimator.SetBool(_LOSE, true);
        coinBody.linearDamping = 13;
    }
}
