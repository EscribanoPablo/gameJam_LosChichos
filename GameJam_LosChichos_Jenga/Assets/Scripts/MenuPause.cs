using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPause : MonoBehaviour
{
    public GameObject m_PanelPause;

    public KeyCode m_PauseKey;

    GameController m_GameController;

    private void Awake()
    {
        m_GameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        m_PanelPause.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(m_PauseKey))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        m_PanelPause.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        m_PanelPause.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RestartGame()
    {
        m_PanelPause.SetActive(false);
        m_GameController.RestartGame();
        Time.timeScale = 1;
        //SceneManager.LoadSceneAsync("nuevatorre");
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadSceneAsync("Menú");
    }

}
