using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PausePanel : MonoBehaviour
{

    public GameManager gameManagerScript;


    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void OpenPanel()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneNavigator.GoToMenu();
    }

    public void SaveGame()
    {
        gameManagerScript.saveGame();
    }

    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
