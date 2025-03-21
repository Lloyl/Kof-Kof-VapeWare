using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using MiniGame = GameStats.MiniGame;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public ScoreScene scoreScene;

    private GameStats      _stats;
    private List<MiniGame> _shuffledMiniGames = new();
    private MiniGame       _currentGame;

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

    public void NextGame()
    {
        var index = Random.Range(0, _shuffledMiniGames.Count - 1);
        // _currentGame = _shuffledMiniGames[index];
        _currentGame = _shuffledMiniGames[0];

        UIManager.Instance.UpdateRemainingGames();

        LoadNextGame(_currentGame);
        // _shuffledMiniGames.RemoveAt(index);
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

    private void LoadNextGame(MiniGame game)
    {
        // _canStart = false;
        AudioManager.Instance.StopAudio();

        if (_stats.life == 0)
        {
            UIManager.Instance.FailMenu();
            return;
        }

        UIManager.Instance.SetTransitionActive(true);
        UIManager.Instance.UpdateGameTransition(game);

        LevelLoader.Instance.LoadLevel(GameStats.GetSceneName(game.name), LoadSceneMode.Additive);

        UIManager.Instance.SetBackgroundActive(false);
        LevelLoader.Instance.ShowLevel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Menu()
    {
        SceneManager.LoadScene(nameof(GameStats.SceneName.MENU), LoadSceneMode.Single);
    }

    private IEnumerator DecrementLife()
    {
        StartCoroutine(UIManager.Instance.ChangeLifeBar());
        yield return new WaitForSeconds(0.5f);
        _stats.life--;
    }

    private IEnumerator IncrementScore()
    {
        yield return new WaitForSeconds(0.3f);
        _stats.score++;
    }

    private void StartMiniGame()
    {
        // StartCoroutine(loader.ActivateMiniGame());
        UIManager.Instance.SetTransitionActive(false);
        UIManager.Instance.UpdateGameStart(_currentGame);
        // StartCoroutine(LaunchTimer());
        // _stats.Win = false;
    }

    public void GameWin()
    {
        Debug.Log("Game win");
        StartCoroutine(GameResult(true));
    }

    public void GameLost()
    {
        if (_stats.life == 0) UIManager.Instance.FailMenu();
        else StartCoroutine(GameResult(false));
    }

    private IEnumerator GameResult(bool win)
    {
        if (win) yield return IncrementScore();
        else yield return DecrementLife();

        yield return LevelLoader.UnloadLevel(GameStats.GetSceneName(_currentGame.name));

        StartCoroutine(StartShowScore(win));
    }


    private IEnumerator StartShowScore(bool win)
    {
        // show score
        yield return new WaitForSeconds(1.5f); // attendre la fin de l'animation de fin de jeu
        Debug.Log("Show score");
        scoreScene.gameObject.SetActive(true);
        scoreScene.ActivateScoreUI(win);
    }
}

// TODO:
// - corriger le bug de la transition entre les jeux et du rideau qui ne s'ouvre pas
// - finir d'implémenter le remaining games
// - passer par le canvas du Management au lieu de la scène ScoreScene (fais moins de scènes à charger)
// - ajouter un écran de fin de jeu avec le score final, le nombre de vies restantes et un bouton pour retourner au menu
// - continuer de refacto le code pour le rendre plus propre et lisible