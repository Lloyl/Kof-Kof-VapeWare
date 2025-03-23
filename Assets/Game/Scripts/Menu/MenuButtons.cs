using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    
    public void LaunchGame()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(Constants.MANAGEMENT_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}