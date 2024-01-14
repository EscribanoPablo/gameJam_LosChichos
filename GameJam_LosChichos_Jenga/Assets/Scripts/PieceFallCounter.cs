using UnityEngine;

public class PieceFallCounter : MonoBehaviour
{
    float timer;
    public float timeToValidCube;
    bool timerActive;
    public GameController gameController;

    GameOverRetry m_GameOverRetry;

    private void Awake()
    {
        m_GameOverRetry = FindObjectOfType<GameOverRetry>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameController.GetRoundActive())
        {
            if (other.tag == "JengaCube")
            {
                if (timerActive)
                {
                    gameController.RoundFinished();
                    m_GameOverRetry.ShowGameOverHud("You Failed");
                    timerActive = false;
                }
                else
                {
                    timerActive = true;
                }
            }
        }
    }
    private void Update()
    {
        if (timerActive)
        {
            timer += Time.deltaTime;
            if (timer > timeToValidCube)
            {
                timer = 0;
                timerActive = false;
                gameController.AddPoint();
                Debug.Log("puntos +1!!! felicidades eres imbecil");
            }
        }
    }
}
