using UnityEngine;
using UnityEngine.UI;

public class GameSettingsPanel : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle particlesToggle;
   

    private void Start()
    {
        // Initialisation
        volumeSlider.value = GameSettings.Volume;
        particlesToggle.isOn = GameSettings.MuteParticles;

        
    }

    public void UpdateVolume()
    {
        GameSettings.Volume = volumeSlider.value;
        
    }

    public void UpdateParticles()
    {
        GameSettings.MuteParticles = particlesToggle.isOn;
        Debug.Log(GameSettings.MuteParticles);
    }

    //Changer
    public void UpdateDifficulty(bool state)
    {
        GameSettings.MuteParticles = state;
    }

    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
