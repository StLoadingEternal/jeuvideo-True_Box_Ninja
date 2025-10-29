using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //private Button continueButton;
    void Start()
    {
        SceneManager.LoadScene("Menu");
        //continueButton.interactable = PlayerPrefs.HasKey("SaveExists");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public static void ExitApp()
    {
        Application.Quit();
    }
}
