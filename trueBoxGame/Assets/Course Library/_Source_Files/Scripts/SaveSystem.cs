using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;


[System.Serializable]
public class GameState
{
    public int score;
    public int lives;
    public int difficulty;
}


public class SaveSystem : MonoBehaviour
{
    private static string savePath;

    private void Awake()
    {
        // Initialiser ici, quand Unity est prêt
        savePath = Path.Combine(Application.persistentDataPath, "save.json");
    }


    public static void SaveGame(GameState state) 
    {
        
        string json = JsonConvert.SerializeObject(state, Formatting.Indented);
        File.WriteAllText(savePath, json);
        Debug.Log($"Jeu sauvegardé dans : {savePath}");
    }

    public static bool CheckHasSave()
    {
        return File.Exists(savePath);
    }

    public static GameState LoadStateFromSave() // pour faire la relecture
    {
        if (!File.Exists(savePath))
        {
            Debug.LogWarning("Aucune sauvegarde trouvée !");
            return null;
        }

        string json = File.ReadAllText(savePath);
        GameState state = JsonConvert.DeserializeObject<GameState>(json);
        Debug.Log("Sauvegarde chargée !");
        return state;
    }
}
