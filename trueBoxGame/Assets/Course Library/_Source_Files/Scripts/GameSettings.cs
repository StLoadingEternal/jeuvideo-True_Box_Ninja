using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private const string VOLUME_KEY = "Volume";
    private const string PARTICLES_KEY = "Particles";
    private const string DIFFICULTY_KEY = "Difficulte";
    private const string CHARGE_SAVE_KEY = "Continuer";

    public static float Volume
    {
        get => PlayerPrefs.GetFloat(VOLUME_KEY, defaultValue: 1f);
        set
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, value);
            PlayerPrefs.Save();
        }
    }

    public static bool MuteParticles
    {
        get => PlayerPrefs.GetInt(PARTICLES_KEY, defaultValue: 1) == 1;
        set
        {
            PlayerPrefs.SetInt(PARTICLES_KEY, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static bool ChargeSave
    {
        get => PlayerPrefs.GetInt(CHARGE_SAVE_KEY, defaultValue: 0) == 1;
        set
        {
            PlayerPrefs.SetInt(CHARGE_SAVE_KEY, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
    public static float Difficulty
    {
        get => PlayerPrefs.GetFloat(DIFFICULTY_KEY, defaultValue: 1f) ;
        set
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, value );
            PlayerPrefs.Save();
        }
    }
}
