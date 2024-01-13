using UnityEngine;

public class PieceFallCounter : MonoBehaviour
{
    float timer;
    public float timeToValidCube;
    bool timerActive;
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (gameController.GetRoundActive())
        {
            if (other.tag == "JengaCube")
            {
                if (timerActive)
                {
                    gameController.RoundFinished();
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
