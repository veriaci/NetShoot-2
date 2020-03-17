using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    public ParticleSystem endFlash;
    public AudioSource winSound;

    void OnCollisionEnter (Collision collisionInfo){
        if (collisionInfo.collider.name == "Player"){
            endFlash.Play();
            winSound.Play();
            Destroy(gameObject);
            gameManager.CompleteLevel();
        }
    }
}
/*
Reference:
    https://www.youtube.com/watch?v=gAB64vfbrhI&list=PLPV2KyIb3jR53Jce9hP7G5xC4O9AgnOuL&index=6
    https://www.youtube.com/watch?v=Iv7A8TzreY4
*/