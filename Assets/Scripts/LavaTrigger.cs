using UnityEngine;

public class LavaTrigger : MonoBehaviour
{
    public GameManager gameManager;

    public AudioSource dieSound;

    void OnCollisionEnter (Collision collisionInfo){
        if (collisionInfo.collider.name == "Player"){
            dieSound.Play();
            gameManager.EndGame();
        }
    }
}
/*
Reference:
    https://www.youtube.com/watch?v=gAB64vfbrhI&list=PLPV2KyIb3jR53Jce9hP7G5xC4O9AgnOuL&index=6
    https://www.youtube.com/watch?v=Iv7A8TzreY4
*/