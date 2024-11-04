using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;         // Game Over UI Panel
    public TextMeshProUGUI countdownText; // TMP countdown text
    public float gameOverDelay = 2f;      // Delay before countdown starts

    private void Start()
    {
        gameOverUI.SetActive(false);      // Hide Game Over UI initially
        countdownText.gameObject.SetActive(false); // Hide countdown initially
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);       // Show "Game Over"
        Time.timeScale = 0f;              // Freeze the game
        StartCoroutine(ShowCountdownAfterDelay());
    }

    private IEnumerator ShowCountdownAfterDelay()
    {
        yield return new WaitForSecondsRealtime(gameOverDelay); // Wait in real-time
        gameOverUI.SetActive(false);       // Hide "Game Over"
        countdownText.gameObject.SetActive(true); // Show countdown

        yield return StartCoroutine(CountdownToReset());
    }

    private IEnumerator CountdownToReset()
    {
        for (int i = 5; i > 0; i--)
        {
            countdownText.text = i.ToString(); // Update countdown text
            yield return new WaitForSecondsRealtime(1); // Wait 1 second in real-time
        }
        ResetScene(); // Call reset method after countdown
    }

    private void ResetScene()
    {
        Time.timeScale = 1f;               // Unfreeze the game before reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
