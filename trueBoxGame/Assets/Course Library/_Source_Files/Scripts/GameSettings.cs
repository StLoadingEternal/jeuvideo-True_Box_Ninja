using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private const string VOLUME_KEY = "Volume";
    private const string PARTICLES_KEY = "Particles";

    public static float Volume
    {
        get => PlayerPrefs.GetFloat(VOLUME_KEY, defaultValue: 1f);
        set
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, value);
            PlayerPrefs.Save();
        }
    }

    public static bool ShowParticles
    {
        get => PlayerPrefs.GetInt(PARTICLES_KEY, defaultValue: 1) == 1;
        set
        {
            PlayerPrefs.SetInt(PARTICLES_KEY, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }
}
