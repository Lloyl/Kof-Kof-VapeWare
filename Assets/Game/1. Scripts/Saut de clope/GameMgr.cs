using System.Collections;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static GameMgr GManager;

    private bool            _win = true;
    private bool            _timerEnded;
    private bool            _canPlayAudioClip = true;
    private PlayerCollision _playerCollision;

    [SerializeField] private GameObject victory;

    [SerializeField] private GameObject lost;
    [SerializeField] private GameObject gameOverBackground;

    [SerializeField] private GameObject victoryBackground;

    private void Awake()
    {
        GManager = this;
    }

    private void Start()
    {
        StartCoroutine(nameof(WinOrLose));
        AudioManager.Instance.PlayAudio("Ambiance saut de clope");
        _canPlayAudioClip = true;
    }

    private void Update()
    {
        switch (_timerEnded)
        {
            case true when !PlayerCollision.Collision.GetIsHit():
            {
                GameStats.Instance.Win = true;
                print("on gagne");
                if (_canPlayAudioClip)
                {
                    AudioManager.Instance.PlayAudio("Victoire Saut De Clope");
                    _canPlayAudioClip = false;
                }

                victory.SetActive(true);
                victoryBackground.SetActive(true);
                break;
            }
            case true when PlayerCollision.Collision.GetIsHit():
            {
                print("on perd");
                if (_canPlayAudioClip)
                {
                    AudioManager.Instance.PlayAudio("Defaite saut de clope");
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