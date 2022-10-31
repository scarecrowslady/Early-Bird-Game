using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //basic player info
    public TMP_Text playerName;
    public TMP_Text playerHiScore;
    public TMP_Text scoreText;

    public Image playerBody;

    //player health
    public float playerHealth;
    public float playerMaxHealth;
    public GameObject healthBar;
    public Slider healthBarSlider;
    public TMP_Text currentHealth;
    public TMP_Text totalHealth;

    //for hiscores
    public string lastPlayerName;
    public float lastPlayerScore;
    public string bestPlayerName;
    public float bestPlayerScore;

    //for hiscores table
    //[SerializeField] HighscoreHandler highscoreHandler;

    //game ui panel
    public GameObject mainGameUIPanel;
    public GameObject pauseGamePanel;

    //game ending screen
    public TMP_Text gameReturnHiScore;

    //game state
    public bool isGameJustEnded;

    // Start is called before the first frame update
    void Start()
    {
        //initialize opening display
        playerName.text = MainManager.Instance.PlayerName;
        scoreText.text = MainManager.Instance.PlayerHiScore + "";

        Debug.Log(MainManager.Instance.PlayerChara);

        //player health stuff
        healthBarSlider.maxValue = MainManager.Instance.PlayerMaxHealth;
        healthBarSlider.minValue = 0;
        healthBarSlider.value = MainManager.Instance.PlayerHealth;

        currentHealth.text = MainManager.Instance.PlayerHealth + "";
        totalHealth.text = "/ " + MainManager.Instance.PlayerMaxHealth + "";

        //controlling game states
        mainGameUIPanel.SetActive(true);
        pauseGamePanel.SetActive(false);

        isGameJustEnded = false;
        MainManager.Instance.IsGameJustEnded = isGameJustEnded;

        Time.timeScale = 1;

        MainManager.Instance.IsGameSaved = false;
        MainManager.Instance.IsGameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //info
        playerName.text = MainManager.Instance.PlayerName;
        playerHiScore.text = MainManager.Instance.PlayerHiScore + "";

        //ending the game
        if (MainManager.Instance.PlayerHealth <= 0)
        {
            MainManager.Instance.IsGameEnded = true;     

            GameOverScreen();
        }
    }

    public void ManagingHealth(float healthHit)
    {
        MainManager.Instance.PlayerHealth += healthHit;

        healthBarSlider.value = MainManager.Instance.PlayerHealth;
        currentHealth.text = MainManager.Instance.PlayerHealth + "";
    }

    public void AddingPoints(float scorePoint)
    {
        MainManager.Instance.PlayerHiScore += scorePoint;

        scoreText.text = MainManager.Instance.PlayerHiScore + "";
    }

    public void ManageBestLastScores()
    {
        MainManager.Instance.LastPlayerName = MainManager.Instance.PlayerName;
        MainManager.Instance.LastPlayerScore = MainManager.Instance.PlayerHiScore;

        if (MainManager.Instance.PlayerHiScore > MainManager.Instance.BestPlayerScore)
        {
            MainManager.Instance.BestPlayerScore = MainManager.Instance.PlayerHiScore;
            MainManager.Instance.BestPlayerName = MainManager.Instance.PlayerName;
        }

        MainManager.Instance.SaveInfo();
    }

    #region Managing Game States
    public void GoBack()
    {
        Time.timeScale = 0;

        SaveGame();
        SceneManager.LoadScene("Menu");
    }

    //with a game ended
    public void EndedGame()
    {
        Time.timeScale = 0;

        isGameJustEnded = true;
        MainManager.Instance.IsGameJustEnded = isGameJustEnded;

        //highscoreHandler.AddHighscoreIfPossible(new HighscoreElement(MainManager.Instance.PlayerName, MainManager.Instance.PlayerHiScore));
        ManageBestLastScores();        

        SceneManager.LoadScene("Menu");
    }

    public void SaveGame()
    {
        MainManager.Instance.IsGameSaved = true;

        MainManager.Instance.SaveInfo();
    }

    public void GameOverScreen()
    {
        Time.timeScale = 0;

        gameReturnHiScore.text = "HiScore: " + MainManager.Instance.PlayerHiScore + "";

        mainGameUIPanel.SetActive(false);
        pauseGamePanel.SetActive(true);
    }
    #endregion
}
