using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //private Button continueButton;
    void Start()
    {
        //Demarre le jeu sur la scène menu
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Aller à la scène menu
    public static void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    //Aller à la scène game
    public static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Sortir du jeu
    public static void ExitApp()
    {
        Application.Quit();
    }
}
