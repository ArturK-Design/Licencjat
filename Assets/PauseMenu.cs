using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerUI;

    

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GamePaused)
            {
                Resume();
                Cursor.visible = false;
                //Debug.Log("PauseMenuClosed");
            }
            else
            {
                Pause();
                Cursor.visible = true;
                //Debug.Log("PasueMenuOpened");
            }
        }
    }
     public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        playerUI.SetActive(true);       
    }

   void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.01f;
        GamePaused = true;
        playerUI.SetActive(false);        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("ReturnedToMenu");
    }
      
}
