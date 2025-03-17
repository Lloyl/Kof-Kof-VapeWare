using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    
    public void LaunchGame()
    {
        loadingScreen.SetActive(true);
        LevelLoader.Instance.LoadLevel(Constants.MANAGEMENT_SCENE, withTransition: false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}