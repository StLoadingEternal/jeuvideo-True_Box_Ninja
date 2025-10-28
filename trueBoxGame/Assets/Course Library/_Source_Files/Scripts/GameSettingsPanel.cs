using UnityEngine;
using UnityEngine.UI;

public class GameSettingsPanel : MonoBehaviour
{
    private Slider volumeSlider;
    private Toggle particlesToggle;
    private GameObject panelRoot;

    private void Start()
    {
        // Initialisation
        volumeSlider.value = GameSettings.Volume;
        particlesToggle.isOn = GameSettings.ShowParticles;

        // Ajout des listeners
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        particlesToggle.onValueChanged.AddListener(UpdateParticles);
    }

    public void UpdateVolume(float value)
    {
        GameSettings.Volume = value;
        AudioListener.volume = value;
    }

    public void UpdateParticles(bool state)
    {
        GameSettings.ShowParticles = state;
    }

    public void ClosePanel()
    {
        panelRoot.SetActive(false);
    }
}
