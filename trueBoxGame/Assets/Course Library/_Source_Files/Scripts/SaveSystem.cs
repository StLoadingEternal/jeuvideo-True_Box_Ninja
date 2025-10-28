
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    [System.Serializable]
    public class GameState
    {
        public int score;
        public int lives;
        public int difficulty;
    }

    private static string savePath = Application.persistentDataPath + "/save.json";

    public static void SaveGame(GameState state) 
    {
        string json = JsonConvert.SerializeObject(state, Formatting.Indented);
        File.WriteAllText(savePath, json);
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
        return JsonConvert.DeserializeObject<GameState>(json);
    }
}
