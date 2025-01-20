using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    public void LaunchGame()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        var async = SceneManager.LoadSceneAsync("Management", LoadSceneMode.Single);
        if (async == null) yield break;
        
        async.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(3f);

        async.allowSceneActivation = true;
    }
}
