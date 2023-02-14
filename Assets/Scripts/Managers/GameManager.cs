using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    ScoringManager scoringManager;

    private GameObject[] enemies;

    [Header("Game Logic Attributes")]
    public GameObject Player;
    public GameObject gameOverCanvas;
    public GameObject youWinCanvas;

    [Header("Slow Motion Attributes")]
    public float slowMotionTime;
    public float ChangePerSecond;
    private float startTimeScale;
    private float fixedTimeScale;

    [Header("Sound Attributes")]
    public AudioSource playerAudioSource;

    [Header("Game Logic Flags")]
    public bool isGameOver;
    public bool isObjectiveCompleted;


    private void Awake()
    {
        scoringManager = GetComponent<ScoringManager>();
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
    }

    private void Start()
    {
        startTimeScale = Time.timeScale;
        fixedTimeScale = Time.fixedDeltaTime;
        Time.timeScale = 1;
        playerAudioSource.pitch = 1;
        ScoringManager.score = 0;

        isGameOver = false;
        isObjectiveCompleted = false;
        gameOverCanvas.SetActive(false);
        youWinCanvas.SetActive(false);
    }

    private void Update()
    {
        HandleWinningState();
        HandleGameOverState();  
    }

    private void HandleWinningState()
    {
        if (isGameOver == true)
        {
            return;
        }

        if (ScoringManager.score == 12)
        {
            HandleSlowMotion();
            isObjectiveCompleted = true;
            youWinCanvas.SetActive(true);
            playerAudioSource.pitch = 1.5f;
            //Debug.Log("You win");
        }
    }

    private void HandleGameOverState()
    {
        PlayerStats playerStats = Player.GetComponent<PlayerStats>();
        
        if (isObjectiveCompleted == true)
        {
            return;
        }

        if (playerStats.currentHealth <= 0)
        {
            isGameOver = true;
            gameOverCanvas.SetActive(true);
            playerAudioSource.pitch = 0.5f;
            //Debug.Log("Game Over");
        }
    }

    private void HandleSlowMotion()
    {
        slowMotionTime -= ChangePerSecond * Time.deltaTime;
        Time.timeScale = slowMotionTime;
        Time.fixedDeltaTime = fixedTimeScale * slowMotionTime;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

