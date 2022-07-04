using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;
    public bool firstFase;
    
    public GameObject win;
    public GameObject lost;
    public GameObject gameOver;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if (firstFase) {
            totalScore = 0;
            scoreText.text = totalScore.ToString();
        } else {
            totalScore = PlayerPrefs.GetInt("score");
            scoreText.text = totalScore.ToString();
        }
    }

    public void UpdateScoreText()
    {
        PlayerPrefs.SetInt("score", totalScore);
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        totalScore = 0;
        PlayerPrefs.SetInt("score", totalScore);
        gameOver.SetActive(true);
    }
    
    public void ShowWin()
    {
        win.SetActive(true);
    }
    
    public void ShowLost()
    {
        lost.SetActive(true);
    }

    public void RestartGame(string lvl_name)
    {
        SceneManager.LoadScene(lvl_name);
    }

}
