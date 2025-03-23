using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ShuffleMiniGames();
        NextGame();
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
            var rand = Random.Range(0, GameStats.Instance.miniGames.Count - 1);

            _shuffledMiniGames.Add(GameStats.Instance.miniGames[rand]);
        }
    }

    private void LoadNextGame(MiniGame game)
    {
        AudioManager.Instance.StopEffects();
        scoreScene.gameObject.SetActive(false);

        UIManager.Instance.SetBackgroundActive(false);
        LevelLoader.Instance.LoadLevel(GameStats.GetSceneName(game.name), LoadSceneMode.Additive);
    }
    
    public void GameWin()
    {
        StartCoroutine(GameResult(true));
    }

    public void GameLost()
    {
        StartCoroutine(GameResult(false));
    }

    private IEnumerator GameResult(bool win)
    {
        if (win) GameStats.Instance.score += 10;

        UIManager.Instance.SetBackgroundActive(true);
        yield return LevelLoader.UnloadLevel(GameStats.GetSceneName(_currentGame.name));
        
        StartShowScore(win);
    }

    private void StartShowScore(bool win)
    {
        scoreScene.gameObject.SetActive(true);
        scoreScene.ActivateScoreUI(win);
    }
}