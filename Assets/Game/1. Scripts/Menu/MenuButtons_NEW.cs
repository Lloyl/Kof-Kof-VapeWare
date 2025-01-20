using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons_NEW : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    
    public void LaunchGame()
    {
        // StartCoroutine(StartGame());
        LevelLoader.Instance.LoadLevel(Constants_NEW.MANAGEMENT_SCENE);
    }

    private IEnumerator StartGame()
    {
        var async = SceneManager.LoadSceneAsync(Constants_NEW.MANAGEMENT_SCENE, LoadSceneMode.Single);
        if (async == null) yield break;
        
        async.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        yield return new WaitForSeconds(3f);

        async.allowSceneActivation = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}