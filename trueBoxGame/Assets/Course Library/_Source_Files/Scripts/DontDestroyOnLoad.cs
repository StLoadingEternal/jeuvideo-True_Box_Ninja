using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLOad : MonoBehaviour
{
    private static DontDestroyOnLOad instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {

        if (FindObjectsByType<DontDestroyOnLOad>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
