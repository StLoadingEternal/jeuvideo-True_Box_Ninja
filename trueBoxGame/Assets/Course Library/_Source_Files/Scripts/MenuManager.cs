using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
     public Button continueButton;//Référence sur le bouton continuer
     public GameObject settingsPanel;//Références sur la fenêtre des paramètres utilisateurs

    private void Start()
    {
        
        continueButton.gameObject.SetActive(SaveSystem.CheckHasSave());//Cache le bouton continuer si aucune sauvegarde existe

        //On s'assure de Fermer les paramètres au démarrage
        settingsPanel.SetActive(false);
    }

    //Lance une nouvelle partie
    public void NewGame()
    {
        GameSettings.ChargeSave = false;
        SceneNavigator.StartGame();
    }

    //Continuer une nouvellePArtie
    public void ContinueGame()
    {
        GameSettings.ChargeSave = true;
        SceneNavigator.StartGame();
    }

    //Fermer les paramètres
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    //Ouvrir les paramètres
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    //Quitter le jeu
    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
