using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int CurrentScore { get; set; }

    [SerializeField] TextMeshProUGUI scoreText;

    public float TimeTillGameOver = 1.5f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        
    }
    private void Update()
    {
        scoreText.text = "Score: " + CurrentScore.ToString();
    }

    public void IncreaseScore(int amount)
    {
        CurrentScore += amount;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
