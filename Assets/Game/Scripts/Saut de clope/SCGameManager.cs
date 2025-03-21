using System.Collections;
using UnityEngine;

public class SCGameManager : MonoBehaviour
{

    private bool            _timerEnded;
    private bool            _canPlayAudioClip = true;
    private PlayerCollision _playerCollision;

    [SerializeField] private GameObject victory;

    [SerializeField] private GameObject lost;
    [SerializeField] private GameObject gameOverBackground;

    [SerializeField] private GameObject victoryBackground;

    private void Start()
    {
        StartCoroutine(WinOrLose());
        AudioManager.Instance.PlayAudio(Audio.SC_AMBIANCE);
        _canPlayAudioClip = true;
    }

    private void Update()
    {
        // mdr a revoir ce code, pas une bonne pratique
        switch (_timerEnded)
        {
            case true when !PlayerCollision.Collision.GetIsHit():
            {
                GameManager.Instance.GameWin();
                print("on gagne");
                if (_canPlayAudioClip)
                {
                    AudioManager.Instance.PlayAudio(Audio.SC_WIN);
                    _canPlayAudioClip = false;
                }

                victory.SetActive(true);
                victoryBackground.SetActive(true);
                break;
            }
            case true when PlayerCollision.Collision.GetIsHit():
            {
                print("on perd");
                GameManager.Instance.GameLost();
                if (_canPlayAudioClip)
                {
                    AudioManager.Instance.PlayAudio(Audio.SC_LOSE);
                    _canPlayAudioClip = false;
                }

                lost.SetActive(true);
                gameOverBackground.SetActive(true);
                break;
            }
        }
    }

    private IEnumerator WinOrLose()
    {
        yield return new WaitForSeconds(5.5f);
        _timerEnded = true;
    }
}