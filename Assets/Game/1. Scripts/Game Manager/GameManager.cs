using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using MiniGame = GameStats.MiniGame;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private SceneLoader loader;
    [SerializeField] private Animator    animator;

    private GameStats      _stats;
    private List<MiniGame> _shuffledMiniGames = new();
    private MiniGame       _currentGame;

    private bool _isRunning;
    private bool _canStart;

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

        _stats             = GameStats.Instance;
        _shuffledMiniGames = ShuffleMiniGames();
        NextGame();
    }

    private void NextGame()
    {
        var index = Random.Range(0, _shuffledMiniGames.Count - 1);
        // _currentGame = _shuffledMiniGames[index];
        _currentGame = _shuffledMiniGames[4];
        
        LoadNextGame(_currentGame);
        _shuffledMiniGames.RemoveAt(index);
        _canStart = true;
    }

    private void Update()
    {
        if (!_canStart) return;

        StartMiniGame();
        _canStart = false;
    }

    private List<MiniGame> ShuffleMiniGames()
    {
        var list = new List<MiniGame>();
        list.AddRange(_stats.miniGames);

        var i   = 0;
        var max = list.Count;

        while (i < max / 2)
        {
            var value1  = list[i];
            var randInt = Random.Range(0, max - 1);

            list[i]       = list[randInt];
            list[randInt] = value1;

            i++;
        }

        return list;
    }

    private IEnumerator LaunchTimer()
    {
        _isRunning = true;
        yield return new WaitForSeconds(_stats.timer);
        _isRunning = false;
        // _canStart   = true;

        animator.SetBool(_stats.Win ? "IsWinned" : "IsLost", true);
    }

    private void LoadNextGame(MiniGame game)
    {
        // _canStart = false;
        AudioManager.Instance.StopAudio();

        if (game.landscapeMode)
        {
            UIManager.Instance.LandscapeMode();
        }

        StartCoroutine(!_stats.Win ? DecrementLife() : IncrementScore());

        if (_stats.lifes == 0)
        {
            UIManager.Instance.FailMenu();
        }
        else
        {
            UIManager.Instance.ActivateTransition();
            UIManager.Instance.UpdateGameTransition(game);

            StartCoroutine(loader.ChangeMiniGame(game.name));
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Menu()
    {
        SceneManager.LoadScene(nameof(GameStats.SceneName.Menu), LoadSceneMode.Single);
    }

    private IEnumerator DecrementLife()
    {
        StartCoroutine(UIManager.Instance.ChangeLifeBar());
        yield return new WaitForSeconds(0.5f);
        _stats.lifes--;
    }

    private IEnumerator IncrementScore()
    {
        yield return new WaitForSeconds(0.3f);
        _stats.score++;
    }

    private void StartMiniGame()
    {
        StartCoroutine(loader.ActivateMiniGame());
        UIManager.Instance.HideTransition();
        UIManager.Instance.UpdateGameStart(_currentGame);
        StartCoroutine(LaunchTimer());
        _stats.Win = false;
    }
}