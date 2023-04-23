using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        inGame, gameOver
    }

    public GameState gameState;

    public List<GameObject> sceneObjects;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hScoreText;
    public int difficulty;
    private float spawnRate= 3;

    private int _score;
    private int score
    {
        set
        {
            _score = Mathf.Clamp(value, 0, 99999);
        }
        get
        {
            return _score;
        }
    }

    public TextMeshProUGUI gameOver;
    public Button restartButton;
    public GameObject tittleScreen;

    private void Start()
    {
        HighScore();
    }

    /// <summary>
    /// Metodo que inicia la partida
    /// </summary>
    public void StartGame(float difficulty)
    {
        tittleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTime());
        
        score = 0;
        UpdateScore(0);

        gameState = GameState.inGame;

        spawnRate /= difficulty;
    }

    IEnumerator SpawnTime()
    {
        while (gameState== GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, sceneObjects.Count);
            Instantiate(sceneObjects[index]);
        }
    }

    /// <summary>
    /// Actualiza la puntuación y la muestra en pantalla
    /// </summary>
    /// <param name="scoreToAdd"></param> añadir a la puntuación global
   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void HighScore()
    {
        int maxScore=PlayerPrefs.GetInt("Max_Score", 0);
        hScoreText.text = "H. Score: " + maxScore;
    }

    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt("Max_Score", 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt("Max_Score", score);
        }
    }
    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        gameState = GameState.gameOver;

        SetMaxScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
