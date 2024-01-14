using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverRetry : MonoBehaviour
{
    MenuPause m_MenuPause;
    GameController m_GameController;
    public TextMeshProUGUI m_GameOverType;


    private void Awake()
    {
        m_MenuPause = FindObjectOfType<MenuPause>();
        m_GameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }


    public void ShowGameOverHud(string l_GameOverType)
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        m_GameOverType.text = l_GameOverType;
        Debug.Log("gameOver because: " + l_GameOverType);
    }

    public void Restart()
    {
        m_GameController.RestartGame();
        Cursor.lockState = CursorLockMode.Locked;
        gameObject.SetActive(false);
    }

    public void ReturnMainMenu()
    {
        Restart();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadSceneAsync("Menú");
    }

}
