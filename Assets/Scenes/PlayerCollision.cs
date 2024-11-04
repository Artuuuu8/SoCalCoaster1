using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameOverManager gameOverManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            // Play crash sound
            FindObjectOfType<AudioManager>().PlayCrashSound();

            // Call to show game over screen
            gameOverManager.ShowGameOver();
        }
    }
}




