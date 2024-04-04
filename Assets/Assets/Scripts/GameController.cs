using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

//using UnityEngine.System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject gameOverText;
    public GameObject ScoreText;
    public bool gameOverBool=false;
    public Text scoreText;
    public Text HighScoreText;
    public Text CoinText;
    public Text livesText;
    //public int score;
    // public int CoinsCount=0;
    //public int player_Lives;
    // UI Screens and Canvas handling
    int scoring;
    public GameObject ScoreTextObject;
    public GameObject MainScreen;
    public GameObject MainGameScreen;
    public GameObject ScoreBoardScreen;
    public GameObject BuyLivesScreen;

    private string playerLivesData="playersLivesData";
    private string scoreCountData="scoreCountData";
    private string coinsCountData="coinsCountData";
    public float scrollSpeed=1.5f;
private void OnEnable()
    {
    Firebase.FirebaseApp app;

        // This code will be executed when the script is enabled or re-enabled
        Debug.Log("Script enabled!");

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
  var dependencyStatus = task.Result;
  if (dependencyStatus == Firebase.DependencyStatus.Available) {
    // Create and hold a reference to your FirebaseApp,
    // where app is a Firebase.FirebaseApp property of your application class.
       app = Firebase.FirebaseApp.DefaultInstance;
        Debug.Log("Script enabled! connected");

    // Set a flag here to indicate whether Firebase is ready to use by your app.
  } else {
    UnityEngine.Debug.LogError(System.String.Format(
      "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
    // Firebase Unity SDK is not safe to use here.
  }
});
}
    private void Awake() 
    {
        if (PlayerPrefs.GetInt(playerLivesData)>0)
        {
            Debug.Log("Check for lives in if " + PlayerPrefs.GetInt(playerLivesData));
            livesText.text = PlayerPrefs.GetInt(playerLivesData).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(playerLivesData, 3);
            PlayerPrefs.Save();

            livesText.text = PlayerPrefs.GetInt(playerLivesData).ToString();

            Debug.Log("Check for lives in else part " + PlayerPrefs.GetInt(playerLivesData));
        }
        if (PlayerPrefs.GetInt(scoreCountData)>0)
        {
           Debug.Log("Check for score in if " + PlayerPrefs.GetInt(scoreCountData));
            scoreText.text = "Score : "+ PlayerPrefs.GetInt(scoreCountData).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(scoreCountData, 0);
            PlayerPrefs.Save();

            scoreText.text = "Score : 0";
        }
        if (PlayerPrefs.GetInt(coinsCountData)>0)
        {
            Debug.Log("Check for coins in if " + PlayerPrefs.GetInt(coinsCountData));
            CoinText.text = PlayerPrefs.GetInt(coinsCountData).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(coinsCountData, 0);
            PlayerPrefs.Save();

            CoinText.text = "0";
        }

        if (instance==null)
        {
            instance=this;
        }
        else if (instance!=this)
        {
            Destroy(gameObject);
        } 
        Time.timeScale=0.1f;  
    }
    public void StartButton()
    {
        ScoreTextObject.SetActive(true);
        MainScreen.SetActive(false);
        Time.timeScale=1f;
        MainGameScreen.SetActive(true);
       // SceneManager.LoadScene("MainScene");
    }
    public void QuitGame()
    {
    Application.Quit();
 
    }
    public void RestartButton()
    {
        if (PlayerPrefs.GetInt(playerLivesData)> 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            BuyLivesScreen.SetActive(true);
            //PlayerPrefs.DeleteAll();
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }
    }
    public void ReloadGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BuyLivesBtnPress()
    {
        PlayerPrefs.SetInt(playerLivesData, 2);
        RestartButton();
    }
    public void SkipLivesButton()
    {
        int valueScore = PlayerPrefs.GetInt(scoreCountData);
        HighScoreText.text ="Your Score is : " +valueScore.ToString();

       // PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("HighestValue",valueScore);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public bool LiveCheck()
    {
        if (PlayerPrefs.GetInt(playerLivesData) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        livesText.text = PlayerPrefs.GetInt(playerLivesData).ToString();
        //=========================
              // AM Mani's controlling scrolling here code commented
        // if (PlayerPrefs.GetInt(scoreCountData) != 0 && PlayerPrefs.GetInt(scoreCountData) % 15 == 0)
        // {
        //     float Speeder = Random.Range(0.6f, 1.0f);
        //     scrollSpeed = scrollSpeed - Speeder;
        //  // CoinsCount = CoinsCount + 1;
        //  // PlayerPrefs.SetInt(coinsCountData, CoinsCount);
        //  // CoinText.text = CoinsCount.ToString();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // if(gameOverBool==true&&Input.GetMouseButtonDown(0))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }
     
    }
    public void PlayerScored()
    {
       if(gameOverBool)
       {
           return;
       } 
       else
       {
            
            //scoring = PlayerPrefs.GetInt(scoreCountData);
            //scoring+=1;
            PlayerPrefs.SetInt(scoreCountData, PlayerPrefs.GetInt(scoreCountData)+1);
            //int coinsIncrement = PlayerPrefs.GetInt(coinsCountData);
           // coinsIncrement+=1;
          //  CoinsCount=CoinsCount+1;
            PlayerPrefs.SetInt(coinsCountData, PlayerPrefs.GetInt(coinsCountData)+1);
            PlayerPrefs.Save();

            CoinText.text = PlayerPrefs.GetInt(coinsCountData).ToString();
            scoreText.text="Score : "+PlayerPrefs.GetInt(scoreCountData).ToString();
            Debug.Log("Here in Player scored");
            //=================================
      // AM Mani's controlling scrolling here code commented
        // if (PlayerPrefs.GetInt(scoreCountData) != 0 && PlayerPrefs.GetInt(scoreCountData) % 15 == 0)
        // {
        //     float Speeder=Random.Range(0.6f,1.0f);
        //     scrollSpeed=scrollSpeed-Speeder;
        // }
       }
    }
    public void BirdDied()
    {
        if (PlayerPrefs.GetInt(playerLivesData) > 0)
        {
            int livesCount = PlayerPrefs.GetInt(playerLivesData);
            --livesCount;
            PlayerPrefs.SetInt(playerLivesData, livesCount);
            PlayerPrefs.Save();

            livesText.text = "" + livesCount.ToString();

        }
        else
        {
            ScoreText.SetActive(false);
            gameOverText.SetActive(true);
            HighScoreText.text = PlayerPrefs.GetInt(scoreCountData).ToString();
            ScoreBoardScreen.SetActive(true);
            gameOverBool = true;
        }
    }
}