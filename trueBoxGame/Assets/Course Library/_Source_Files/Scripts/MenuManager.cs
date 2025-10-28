using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
     private Button continueButton;
     private GameObject settingsPanel;

    private void Start()
    {
        
        continueButton.gameObject.SetActive(SaveSystem.CheckHasSave());
        // Ferme les paramètres au démarrage
        settingsPanel.SetActive(false);
    }

    public void NewGame()
    {
        SaveSystem.SaveGame(new SaveSystem.GameState());
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

    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
