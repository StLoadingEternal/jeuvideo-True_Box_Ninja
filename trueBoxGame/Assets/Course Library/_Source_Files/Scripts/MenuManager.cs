using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
     public Button continueButton;
     public GameObject settingsPanel;

    private void Start()
    {
        
        continueButton.gameObject.SetActive(SaveSystem.CheckHasSave());
        // Ferme les paramètres au démarrage
        settingsPanel.SetActive(false);
    }

    public void NewGame()
    {
        //SaveSystem.SaveGame(new GameState());
        SceneNavigator.StartGame();
    }

    public void ContinueGame()
    {
        SceneNavigator.StartGame();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
