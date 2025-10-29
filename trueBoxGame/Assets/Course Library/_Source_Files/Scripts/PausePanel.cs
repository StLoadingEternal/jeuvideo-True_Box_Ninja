using UnityEngine;

public class PausePanel : MonoBehaviour
{
    private GameObject panel;



    private void Start()
    {
        panel = GetComponent<GameObject>();
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneNavigator.GoToMenu();
    }

    public void SaveGame()
    {
        var state = new GameState
        {
            score = 100, // exemple
            lives = 3,
            difficulty = 1
        };
        SaveSystem.SaveGame(state);
    }

    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
