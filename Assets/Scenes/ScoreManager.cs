using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GroundMovement groundMovement;
    
    private float score = 0f;
    private int highScore = 0;
    private float multiplier = 1f;  // Default multiplier
    private float boostDuration = 5f;  // Duration of each multiplier boost

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    private void Update()
    {
        // Increment score based on ground speed and multiplier
        float speedMultiplier = groundMovement.speed;
        score += speedMultiplier * multiplier * Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

        // Update high score if needed
        if (score > highScore)
        {
            highScore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public void ActivateScoreMultiplier(float newMultiplier, float duration)
    {
        // Start the coroutine to boost the multiplier
        StartCoroutine(ScoreMultiplierCoroutine(newMultiplier, duration));
    }

    private IEnumerator ScoreMultiplierCoroutine(float newMultiplier, float duration)
    {
        multiplier = newMultiplier;
        yield return new WaitForSeconds(duration);
        multiplier = 1f;  // Reset to default multiplier after duration
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
