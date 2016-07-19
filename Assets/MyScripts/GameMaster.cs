using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

    public GameObject gameOverPanel;
    public GameObject menuPanel;
    public AudioSource aSource;
    public AudioClip scoreClip;

    public bool menu;
    public Text scoreText;
    public Text highScoreText;

    public float Score;
    public int HighScore;
    public float scoreMultiplier;

    public float jumpHeight;

    public float speed;
    public float minSpeed;
    public float maxSpeed;

    public float BGMultiplier;

    public float obstilceMin;
    public float obsticleMax;

    public float despawn;

    private string hs_pref = "HighScore";
    private bool playedScoreSound;

    private RestartGame restart;

    void Start()
    {
        playedScoreSound = false;
        restart = GameObject.FindGameObjectWithTag("Restart").GetComponent<RestartGame>();
        menu = restart.restart;
        ToggelMenu();
        speed = minSpeed;
        if (gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(false);
        }
        HighScore = PlayerPrefs.GetInt(hs_pref);
        Input.simulateMouseWithTouches = true;
    }

    void Update()
    {
        float scoreToAdd = Time.deltaTime * scoreMultiplier;
        Score += scoreToAdd;

        if((int)Score >= HighScore)
        {
            //Debug.Log("New High Score");
            PlayerPrefs.SetInt(hs_pref, (int)Score);
        }
        IncreaseSpeed();
        UpdateGUI();
        PlayScoreAudio();
    }

    private void PlayScoreAudio()
    {
        if((int)Score % 100 == 0 && (int)Score > 0 && ! playedScoreSound)
        {
            playedScoreSound = true;
            aSource.PlayOneShot(scoreClip, 1);
        }
        else if( (int)Score % 100 != 0)
        {
            playedScoreSound = false;
        }
    }

    private void IncreaseSpeed()
    {
        float multiplier = 1 + (Score / 1000f);
        speed = (minSpeed) * multiplier;

        if (speed <= minSpeed)
        {
            speed = minSpeed;
        }

        if (speed >= maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    private void UpdateGUI()
    {
        scoreText.text = ((int)Score).ToString();
        highScoreText.text = "HI " + HighScore.ToString();

    }

    public void GameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void GameOverButton()
    {
        Time.timeScale = 1;
        restart.restart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToggelMenu()
    {
        if (gameOverPanel.activeInHierarchy)
        {
            gameOverPanel.SetActive(false);
        }
        menu = !menu;
        menuPanel.SetActive(menu);
        if (menu)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void startGame()
    {
        if (Score > 0)
        {
            GameOverButton();
        }
        else {
            ToggelMenu();
        }
    }
}
