using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using MiniGame = GameStats.MiniGame;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text message;

    [SerializeField] private GameObject gamePlayTab;
    [SerializeField] private GameObject transitionTab;
    [SerializeField] private GameObject landscapeMode;
    [SerializeField] private GameObject retryTab;

    [SerializeField] private Animator lifeAnimator;

    [SerializeField] private GameplayController gameplayController;

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
        lifeAnimator.SetInteger("LifeLeft", GameStats.Instance.lifes);
        lifeAnimator.SetBool("IsWinned", GameStats.Instance.Win);
    }

    public IEnumerator ChangeLifeBar()
    {
        yield return new WaitForSeconds(0.3f);
        lifeAnimator.SetTrigger("LessOne");
    }

    public void LandscapeMode()
    {
        StartCoroutine(LandscapeModeStart());
    }

    private IEnumerator LandscapeModeStart()
    {
        yield return new WaitForSeconds(3);
        landscapeMode.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        landscapeMode.SetActive(false);
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
}