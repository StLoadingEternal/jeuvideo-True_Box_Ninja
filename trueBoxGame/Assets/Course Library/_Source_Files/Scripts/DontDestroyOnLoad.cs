using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLOad : MonoBehaviour
{
    private static DontDestroyOnLOad instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("Menu");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
