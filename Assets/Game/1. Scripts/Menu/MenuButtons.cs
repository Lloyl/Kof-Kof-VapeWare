using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    
    public void LaunchGame()
    {
        LevelLoader.Instance.LoadLevel(Constants.MANAGEMENT_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}