using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameStats.SceneName sceneLoaded = GameStats.SceneName.None;
    private AsyncOperation      _loading;

    private IEnumerator LoadNextGame(GameStats.SceneName sceneName)
    {
        _loading = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
        if (_loading != null) _loading.allowSceneActivation = false;
        sceneLoaded = sceneName;

        yield return true;
    }

    private IEnumerator UnloadCurrentGame()
    {
        SceneManager.UnloadSceneAsync(sceneLoaded.ToString());

        yield return true;
    }

    public IEnumerator ChangeMiniGame(GameStats.SceneName sceneName)
    {
        if (sceneLoaded != GameStats.SceneName.None)
        {
            StartCoroutine(UnloadCurrentGame());
            yield return false;
        }

        StartCoroutine(LoadNextGame(sceneName));
        yield return true;
        
        sceneLoaded = sceneName;
    }

    public IEnumerator ActivateMiniGame()
    {
        _loading.allowSceneActivation = true;
        yield return true;
    }
}