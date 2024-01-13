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

    private void Start()
    {
        // esto es para probarrrr
        currentTime = roundTime;
        roundActive = true;
    }
    public void AddPoint()
    {
        playerPoints++;
        SetPoints();
    }

    private void SetPoints()
    {
        pointsText.text = playerPoints.ToString();
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
        if (highscore < playerPoints)
        {
            highscore = playerPoints;
            //algo enplan congratulations new highscore!!!
        }
        ResetRound();
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
            }
        }
    }
}
