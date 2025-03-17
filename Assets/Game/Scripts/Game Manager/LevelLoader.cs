using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static readonly int         _START = Animator.StringToHash("Start");
    private static readonly int         _END   = Animator.StringToHash("End");
    public static           LevelLoader Instance { get; private set; }
    

    [SerializeField] private Animator transition;

    [SerializeField] private float transitionTime = 1f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void LoadLevel(string levelName, LoadSceneMode mode = LoadSceneMode.Single, bool withTransition = true)
    {
        StartCoroutine(LoadLevelAsync(levelName, mode, withTransition));
    }

    private IEnumerator LoadLevelAsync(string levelName, LoadSceneMode mode, bool withTransition)
    {
        if (withTransition)
        {
            transition.SetTrigger(_START);
            yield return new WaitForSeconds(transitionTime);
        }

        var async = SceneManager.LoadSceneAsync(levelName, mode);
        if (async == null) yield break;

        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            if (async.progress >= 0.9f)
                async.allowSceneActivation = true;

            yield return null;
        }
    }
    
    public static IEnumerator UnloadLevel(string levelName)
    {
        var async = SceneManager.UnloadSceneAsync(levelName);
        if (async == null) yield break;

        while (!async.isDone)
        {
            yield return null;
        }
    }

    public void ShowLevel()
    {
        transition.SetTrigger(_END);
    }
}