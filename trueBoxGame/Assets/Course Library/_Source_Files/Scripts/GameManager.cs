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

    private float spawnRate = 1f;

    private float baseRate = 3f;

    //Référence sur le gameobject
    public static GameManager instance;

    public List<GameObject> lifeImages;

    public bool gameIsActive = true;

    public GameObject gameOverScreen;

    //Référence sur la source audio
    public AudioSource gameMusic;


    //Références sur le menu pause
    public GameObject PanelPause;

    private PausePanel pausePanelScript;


    // Start is called before the first frame update
    void Start()
    {

        // Initialiser le volume et la difficulté en fonction des paramètres
        if (gameMusic != null)
            gameMusic.volume = GameSettings.Volume;
        spawnRate = baseRate / (GameSettings.Difficulty + 1);//difficulté 1f: un objet tous les 1.5s; difficulté 0f: un objet tous les 3s


        //Si le joueur continue une partie (charge une sauvegarde)
        if (GameSettings.ChargeSave)
        {
            GameState gameSave = SaveSystem.LoadStateFromSave();//On charge la sauvegarde

            //Si la sauvegarde existe on met les données de jeu à jour
            if (gameSave != null)
            {
                score = gameSave.score;
                nLives = gameSave.lives;
                spawnRate = baseRate / (gameSave.difficulty + 1);
            }
            
        }
     
        StartCoroutine(SpawnTargets());

        instance = this;
        
        //Initialiser correctement l'UI
        UpdateScore();
        UpdateLives();
        gameOverScreen.SetActive(false);

        //Réference sur le menu pause
        pausePanelScript = PanelPause.GetComponent<PausePanel>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                pausePanelScript.OpenPanel();
            else
                pausePanelScript.ClosePanel();
        }
    }

    //sauvegarder le jeu en cours à partir des données de jeu
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

    //Relancer le jeu en fin de partie
    public void RestartGame()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void GameOver()
    {
        gameIsActive = false;

        gameOverScreen.SetActive(true);
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
            yield return new WaitForSeconds(spawnRate);
            var index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }
}
