using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButtons : MonoBehaviour
{
    public void Restart()
    {
        AudioManager.Instance.RestartMusic();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Menu()
    {
        AudioManager.Instance.StopMusic();
        LevelLoader.Instance.LoadLevel(Constants.MENU_SCENE);
    }
}
