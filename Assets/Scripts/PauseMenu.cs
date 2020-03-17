using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject crosshair;

    // Update is called once per frame
    void Update()
    {
        if(!GameManager.gameHasEnded){
            if (Input.GetKeyDown(KeyCode.Escape)){
                if (GameIsPaused){
                    Resume();
                }  else {
                    Pause();
                }
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false; 
    }

    public void Pause(){
        pauseMenuUI.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameIsPaused = true;
    }

    public void Restart(){
        Debug.Log("Restarting Game..");
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameManager.gameHasEnded = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMenu(){
        Debug.Log("Loading Menu..");
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameManager.gameHasEnded = false;
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame(){
        Debug.Log("Quitting Game...");
    }
}


/*
References: 
    https://www.youtube.com/watch?v=JivuXdrIHK0
    https://www.youtube.com/watch?v=pbeB9NsaoPs
*/