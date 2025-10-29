using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    


    public List<GameObject> targets;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    private int nLives = 3;
    float spawnRate = 1f;

    public static GameManager instance;

    public List<GameObject> lifeImages;

    public bool gameIsActive = true;

    public GameObject gameOverScreen;

    public AudioSource gameMusic;

    public GameObject PanelPause;

    private PausePanel pausePanelScript;


    // Start is called before the first frame update
    void Start()
    {

        // Initialiser le volume
        if (gameMusic != null)
            gameMusic.volume = GameSettings.Volume;

        // Vérifier si on charge une partie sauvegardée

        //LA même sauvegarde se recharge 
        if (GameSettings.ChargeSave)
        {
            GameState gameSave = SaveSystem.LoadStateFromSave();
            if (gameSave != null)
            {
                score = gameSave.score;
                nLives = gameSave.lives;
                spawnRate = 1f / (gameSave.difficulty + 1);
            }
            
        }
     
        StartCoroutine(SpawnTargets());

        instance = this;
        
        UpdateScore();
        UpdateLives();
        gameOverScreen.SetActive(false);

        pausePanelScript = PanelPause.GetComponent<PausePanel>();
    } 

    public void RestartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );

    }

    public void GameOver()
    {
        gameIsActive = false;

        gameOverScreen.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 1)
                pausePanelScript.OpenPanel();
            else
                pausePanelScript.ClosePanel();
        } 
    }


    public void UpdateScore(int scoreToAdd = 0)
    {
        score += scoreToAdd;

        scoreText.text = $"Score: {score}";
    }

    public void UpdateLives(int livesToAdd = 0)
    {
        nLives += livesToAdd;

        for(int i = 0; i < lifeImages.Count; i++)
        {
            lifeImages[i].SetActive(i < nLives);
        }

        if (nLives <= 0) GameOver();
    }

    private IEnumerator SpawnTargets()
    {
        while (gameIsActive)
        {
            yield return new WaitForSeconds(1f / spawnRate);
            var index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }

    public void saveGame()
    {
        var state = new GameState
        {
            score = score,
            lives = nLives,
            difficulty = GameSettings.Difficulty
        };
        SaveSystem.SaveGame(state);
    }
}
