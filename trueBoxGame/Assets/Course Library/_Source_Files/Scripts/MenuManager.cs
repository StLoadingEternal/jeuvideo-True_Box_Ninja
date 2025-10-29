using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
     public Button continueButton;
     public GameObject settingsPanel;

    private void Start()
    {
        
        continueButton.gameObject.SetActive(SaveSystem.CheckHasSave());

        // Ferme les param�tres au d�marrage
        settingsPanel.SetActive(false);
    }

    public void NewGame()
    {
        GameSettings.ChargeSave = false;
        SceneNavigator.StartGame();
    }

    public void ContinueGame()
    {
        GameSettings.ChargeSave = true;
        SceneNavigator.StartGame();
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
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
