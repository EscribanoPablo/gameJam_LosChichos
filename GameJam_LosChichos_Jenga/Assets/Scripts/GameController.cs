using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    int playerPoints;
    public float roundTime;
    float currentTime;
    int highscore;
    bool roundActive;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI m_HighScoreText;

    HighScore m_HighScoreManager;
    GameOverRetry m_GameOverRetry;
    public PlayerController m_PlayerController;

    public List<JengaCube> m_JengaCubeList;
    private void Awake()
    {
        m_GameOverRetry = FindObjectOfType<GameOverRetry>();
        //m_PlayerController = FindObjectOfType<PlayerController>();
    }
    private void Start()
    {
        // esto es para probarrrr
        m_HighScoreManager = GameObject.FindGameObjectWithTag("HighScore").GetComponent<HighScore>();
        currentTime = roundTime;
        roundActive = true;
        highscore = m_HighScoreManager.value;
        SetPoints();

    }
    public void AddPoint()
    {
        playerPoints++;
        SetHighScore();
        SetPoints();
    }   

    private void SetPoints()
    {
        pointsText.text = playerPoints.ToString();
        m_HighScoreText.text = highscore.ToString();
    }

    private void SetTime()
    {
        timeText.text = currentTime.ToString("0");
    }
    private void ResetRound()
    {
        playerPoints = 0;
        SetPoints();

        currentTime = roundTime;
        SetTime();

        roundActive = false;
    }
    
    public bool GetRoundActive()
    {
        return roundActive;
    }

    public void RoundFinished()
    {
        roundActive = false;
        SetHighScore();
    }

    private void SetHighScore()
    {
        if (highscore < playerPoints)
        {
            highscore = playerPoints;
            m_HighScoreManager.value = highscore;
            //algo enplan congratulations new highscore!!!
        }
    }

    private void Update()
    {
        if (roundActive)
        {
            SetTime();
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                RoundFinished();
                m_GameOverRetry.ShowGameOverHud("Time Finished");
            }
        }

    }

    public void RestartGame()
    {
        ResetRound();
        m_PlayerController.RestartGame();
        foreach (JengaCube l_JengaCube in m_JengaCubeList)
        {
            Debug.Log("restart");
            l_JengaCube.RestartGame();
        }

        roundActive = true;
    }

}
