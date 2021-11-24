using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private Animator anim;
    public GameObject MenuButtons;
    public GameObject MenuCamera;
    public GameObject OptionsMenu;
    

    public void Start()
    {
        anim = MenuCamera.GetComponent<Animator>();
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Cursor.visible = false;
    }
    public void Options()
    {
        MenuButtons.SetActive(false);
        anim.enabled = true;
        anim.Play("MainToOptions");
        OptionsMenu.SetActive(true);
    }
    public void ReturnToMain()
    {
        OptionsMenu.SetActive(false);
        MenuButtons.SetActive(true);
        anim.Play("OptionsToMain");
    }
  
    
}
