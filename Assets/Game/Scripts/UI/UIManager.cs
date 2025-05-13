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
    [SerializeField] private TMP_Text countdown;

    public static UIManager Instance { private set; get; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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
    
    public void UpdateRemainingGames()
    {
        remainingGames.text = $"Restant: {GameStats.Instance.remaining.ToString()}";
    }
    
    public void UpdateCountdown(int time)
    {
        countdown.text = $"Temps: {time}s";
    }
    
    public void SetCountdownActive(bool active)
    {
        countdown.gameObject.SetActive(active);
    }
}