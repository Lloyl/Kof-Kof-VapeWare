using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MiniGame = GameStats.MiniGame;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text message;

    [SerializeField] private GameObject gamePlayTab;
    [SerializeField] private GameObject transitionTab;
    [SerializeField] private GameObject landscapeMode;
    [SerializeField] private GameObject retryTab;
    
    [SerializeField] private Image background;

    [SerializeField] private Animator lifeAnimator;

    [SerializeField] private GameplayController gameplayController;

    [SerializeField] private TMP_Text remainingGames;

    public static UIManager Instance { private set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
    }
    
    public void SetBackgroundActive(bool active)
    {
        background.gameObject.SetActive(active);
    }

    public void FailMenu()
    {
        retryTab.SetActive(true);
        AudioManager.Instance.Fail();
    }

    public void UpdateGameStart(MiniGame game)
    {
        message.text = game.message;
        StartCoroutine(DisplayStartTab());
        gameplayController.ActivateAnimation(game.interaction);
    }

    public void UpdateGameTransition(MiniGame game)
    {
        lifeAnimator.SetInteger("LifeLeft", GameStats.Instance.life);
        // lifeAnimator.SetBool("IsWinned", GameStats.Instance.Win);
    }

    public IEnumerator ChangeLifeBar()
    {
        yield return new WaitForSeconds(0.3f);
        lifeAnimator.SetTrigger("LessOne");
    }

    public void ActivateTransition()
    {
        transitionTab.SetActive(true);
    }

    public void HideTransition()
    {
        transitionTab.SetActive(false);
    }

    private IEnumerator DisplayStartTab()
    {
        gamePlayTab.SetActive(true);
        yield return new WaitForSeconds(1);
        gamePlayTab.SetActive(false);
    }
    
    public void UpdateRemainingGames()
    {
        remainingGames.text = GameStats.Instance.remaining.ToString();
    }
}