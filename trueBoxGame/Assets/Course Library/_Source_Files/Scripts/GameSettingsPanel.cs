using UnityEngine;
using UnityEngine.UI;

public class GameSettingsPanel : MonoBehaviour
{
    //Références sur les handles
    public Slider volumeSlider; 
    public Slider difficultySlider;
    public Toggle particlesToggle;
   

    private void Start()
    {
        // Initialisation des handle à leurs valeurs correctes
        volumeSlider.value = GameSettings.Volume;
        particlesToggle.isOn = GameSettings.MuteParticles;
        difficultySlider.value = GameSettings.Difficulty;
        
    }

    //met à jour le volume de jeu
    public void UpdateVolume()
    {
        GameSettings.Volume = volumeSlider.value;
        
    }

    //Met à jour l'affichage des particules
    public void UpdateParticles()
    {
        GameSettings.MuteParticles = particlesToggle.isOn;
        Debug.Log(GameSettings.MuteParticles);
    }

    //Met à jour la difficulté de jeu
    public void UpdateDifficulty()
    {
        GameSettings.Difficulty = difficultySlider.value;
    }

    //Ferme les settings
    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
