using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using MiniGame = GameStats.MiniGame;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text message;

    [SerializeField] private GameObject gamePlayTab;
    [SerializeField] private GameObject retryTab;

    [SerializeField] private Image background;
    
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

    private void Start()
    {
        UpdateRemainingGames();
    }

    public void SetBackgroundActive(bool active)
    {
        background.gameObject.SetActive(active);
    }

    public void GameOverMenu()
    {
        retryTab.SetActive(true);
        AudioManager.Instance.GameOverAudioMenu();
    }

    // Module non repris, mais qui pourrait être utile (affiche comment jouer au mini jeu)

    // --------------------------
    public void UpdateGameStart(MiniGame game)
    {
        message.text = game.message;
        StartCoroutine(DisplayStartTab());
        gameplayController.ActivateAnimation(game.interaction);
    }

    private IEnumerator DisplayStartTab()
    {
        gamePlayTab.SetActive(true);
        yield return new WaitForSeconds(1);
        gamePlayTab.SetActive(false);
    }

    // --------------------------

    public void UpdateRemainingGames()
    {
        remainingGames.text = GameStats.Instance.remaining.ToString();
    }
}