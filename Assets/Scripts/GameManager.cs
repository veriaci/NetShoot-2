using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject endMenuUI;
    public GameObject deadMenuUI;

    public GameObject crosshair;

    public void CompleteLevel(){
        if (!gameHasEnded){
            gameHasEnded = true;
            Debug.Log ("LEVEL WON!!");
            endMenuUI.SetActive(true);
            crosshair.SetActive(false);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void EndGame(){
        if (!gameHasEnded){
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            deadMenuUI.SetActive(true);
            crosshair.SetActive(false);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Invoke("Restart", restartDelay); 
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}