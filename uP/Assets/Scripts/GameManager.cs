using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GameOver")]
    public static bool GameIsOver;
    [SerializeField] GameObject panelGameOver;
    public int Highscore;
    public TextMeshProUGUI HighscorePoints;

    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if(PlayerBehavior.points > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerBehavior.points);
        }
        Highscore = PlayerPrefs.GetInt("HighScore");
        HighscorePoints.text = Highscore.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0.5f;
        panelGameOver.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Creation.PlataformaAtiva = 0;
        SceneManager.LoadScene(0);
        panelGameOver.SetActive(false);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
