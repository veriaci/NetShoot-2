using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject endMenuUI;
    public GameObject deadMenuUI;

    public GameObject crosshair;

    string URL = "http://localhost/netshoot/scoreInsert.php";
    public string InputId, InputName, InputTime, InputScore;

    public void CompleteLevel(){
        if (!gameHasEnded){
            gameHasEnded = true;
            Debug.Log ("LEVEL WON!!");
            endMenuUI.SetActive(true);
            crosshair.SetActive(false);
            Time.timeScale = 0f;
            Cursor.visible = true;
            AddScore(InputId, InputName, InputTime, InputScore);
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
            AddScore(InputId, InputName, InputTime, InputScore);
            //Invoke("Restart", restartDelay); 
        }
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(string id, string name, string time, string score){
        WWWForm form = new WWWForm ();
        form.AddField("addId", id);
        form.AddField("addName", name);
        form.AddField("addTime", time);
        form.AddField("addScore", score);

        WWW www = new WWW (URL, form);
    }
}