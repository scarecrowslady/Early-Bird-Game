using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuController : MonoBehaviour
{
    //checking whether certain choices have been made
    public bool isPlayerCharaSelected;
    public bool isPlayerNameSelected;

    //error screen if player choices are forgotten
    public GameObject errorCanvas;

    //player choices
    public string playerName;
    public Image playerBody;

    //player input name
    public Button btnClick;
    public TMP_InputField inputPlayerName;
    public string inputPlayerNameText;

    //starting stats
    public float playerHealth;
    public float playerMaxHealth;

    //storing main hiScores
    public TMP_Text lastPlayerName;
    public TMP_Text lastPlayerScore;
    public string lastPlayerNameVar;
    public float lastPlayerScoreVar;

    public TMP_Text bestPlayerName;
    public TMP_Text bestPlayerScore;
    public string bestPlayerNameVar;
    public float bestPlayerScoreVar;

    [SerializeField] HighscoreHandler highscoreHandler;

    //managing game states
    public bool isGameSaved;
    public bool isGameJustEnded;

    // Start is called before the first frame update
    void Start()
    {
        //watching game start state
        isPlayerCharaSelected = false;
        isPlayerNameSelected = false;

        //attach button event
        btnClick.onClick.AddListener(GetInputOnClickHandler);

        //setting high score
        SetCurrentBestPlayer();

        //noting game state
        isGameSaved = MainManager.Instance.IsGameSaved;
        isGameJustEnded = MainManager.Instance.IsGameJustEnded;
    }

    #region choosing stuff    
    public void SetChara(Image playerChara)
    {
        playerBody = playerChara;
        MainManager.Instance.PlayerChara = playerChara;

        isPlayerCharaSelected = true;

        Debug.Log("main menu registers body as:" + playerBody.name);
    }

    public void SetPlayerName(string input)
    {
        inputPlayerNameText = inputPlayerName.text;
        MainManager.Instance.PlayerName = inputPlayerNameText;

        isPlayerNameSelected = true;
    }

    public void GetInputOnClickHandler()
    {
        Debug.Log("Log Input: " + inputPlayerName.text);

        if(!string.IsNullOrEmpty(inputPlayerNameText))
        {
            isPlayerNameSelected = true;
        } else
        {
            isPlayerNameSelected = false;
        }
    }
    #endregion

    #region hiscores stuff
    public void SetCurrentBestPlayer()
    {
        lastPlayerNameVar = MainManager.Instance.LastPlayerName;
        lastPlayerScoreVar = MainManager.Instance.LastPlayerScore;

        lastPlayerName.text = lastPlayerNameVar;
        lastPlayerScore.text = lastPlayerScoreVar + "";

        bestPlayerNameVar = MainManager.Instance.BestPlayerName;
        bestPlayerScoreVar = MainManager.Instance.BestPlayerScore;

        bestPlayerName.text = bestPlayerNameVar;
        bestPlayerScore.text = bestPlayerScoreVar + "";

        MainManager.Instance.SaveInfo();
    }

    //go to hiscore window
    public void GoToHiScores()
    {
        SceneManager.LoadScene("Hiscores");
    }

    public void TriggerHiScoreTabulation()
    {
        if(isGameJustEnded == true)
        {
            highscoreHandler.AddHighscoreIfPossible(new HighscoreElement(MainManager.Instance.LastPlayerName, MainManager.Instance.LastPlayerScore));
        }
    }

    #endregion

    #region manage game states
    public void StartGame()
    {
        if(isPlayerCharaSelected == true && isPlayerNameSelected == true)
        {
            //setting player stats for new game
            MainManager.Instance.PlayerHiScore = 0;

            MainManager.Instance.PlayerHealth = 50;
            MainManager.Instance.PlayerMaxHealth = 50;

            MainManager.Instance.IsGameSaved = false;

            SceneManager.LoadScene("Game");

            isGameJustEnded = false;
        }
        else
        {
            errorCanvas.gameObject.SetActive(true);

            //debug error screen
            Debug.Log("you're missing something");
        }
    }

    public void TriggerLoadedGame()
    {
        if(MainManager.Instance.IsGameSaved == false)
        {
            Debug.Log("there is no saved game sadge");
        }
        else
        {          
            LoadGame();

            isGameJustEnded = false;
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");

        //MainManager.Instance.LoadInfo();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
#endregion
}
