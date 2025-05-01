using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Game_Manager;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using MiniGame = GameStats.MiniGame;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public ScoreScene scoreScene;

    private readonly List<MiniGame> _shuffledMiniGames = new();

    private MiniGame _currentGame;
    
    [CanBeNull] public IGame CurrentGameManager;
    private float _remainingTime;
    
    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        ShuffleMiniGames();
        NextGame();
    }

    private void Update()
    {
        if (_remainingTime <= 0) return;
        
        _remainingTime -= Time.deltaTime;
        var gameTime = Mathf.CeilToInt(_remainingTime);
        
        if (!CurrentGameManager?.IsGameRunning ?? true) return; // if game is running

        UIManager.Instance.UpdateCountdown(gameTime);
        
        if (gameTime > 0) return;
        
        CurrentGameManager?.GameOver();
        _remainingTime = 0;
        UIManager.Instance.SetCountdownActive(false);
    }

    public void NextGame()
    {
        if (GameStats.Instance.remaining <= 0)
        {
            scoreScene.gameObject.SetActive(false);
            UIManager.Instance.GameOverMenu();
            return;
        }

        GameStats.Instance.remaining--;
        _currentGame = _shuffledMiniGames[GameStats.Instance.remaining];

        UIManager.Instance.UpdateRemainingGames();

        LoadNextGame(_currentGame);
    }

    private void ShuffleMiniGames()
    {
        for (var i = 0; i < GameStats.Instance.initialGamesCount; i++)
        {
            var rand = Random.Range(0, GameStats.Instance.miniGames.Count);

            _shuffledMiniGames.Add(GameStats.Instance.miniGames[rand]);
        }
    }

    private void LoadNextGame(MiniGame game)
    {
        AudioManager.Instance.StopEffects();
        scoreScene.gameObject.SetActive(false);

        UIManager.Instance.SetBackgroundActive(false);
        UIManager.Instance.SetCountdownActive(true);
        UIManager.Instance.UpdateCountdown(game.time);
        _remainingTime = game.time;
        
        LevelLoader.Instance.LoadLevel(GameStats.GetSceneName(game.name), LoadSceneMode.Additive);
    }
    
    public void GameResult(bool win)
    {
        StartCoroutine(EndGame(win));
    }
    
    private IEnumerator EndGame(bool win)
    {
        CurrentGameManager = null;

        if (win) GameStats.Instance.score += Constants.WIN_SCORE + Mathf.RoundToInt(_remainingTime);

        UIManager.Instance.SetBackgroundActive(true);
        UIManager.Instance.SetCountdownActive(false);
        
        yield return StartCoroutine(LevelLoader.UnloadLevel(_currentGame.name));
        
        StartShowScore(win);
    }

    private void StartShowScore(bool win)
    {
        scoreScene.gameObject.SetActive(true);
        scoreScene.ActivateScoreUI(win);
    }
}