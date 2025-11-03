using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PausePanel : MonoBehaviour
{

    public GameManager gameManagerScript;//Référence sur le script gameManager


    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Ouvrir le panel de pause
    public void OpenPanel()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    //Fermer le panel de pause
    public void ClosePanel()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    //Aller à la scène menu
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneNavigator.GoToMenu();
    }

    //Sauvegarder le jeu en cours
    public void SaveGame()
    {
        gameManagerScript.saveGame();
    }

    //Quitter le jeu
    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
