using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int playerScore = 0;

    public int PlayerScore
    {
        get { return playerScore; }
    }

    private void Start()
    {
        // Prevent this GameObject from being destroyed when loading a new scene.
        DontDestroyOnLoad(gameObject);

        // Load the player's score from PlayerPrefs or another data source if needed.
        playerScore = PlayerPrefs.GetInt("PlayerScore", 0);
    }

    public void IncrementScore(int amount)
    {
        playerScore += amount;
        SavePlayerScore();
    }

    public void ResetScore()
    {
        playerScore = 0;
        SavePlayerScore();
    }

    private void SavePlayerScore()
    {
        PlayerPrefs.SetInt("PlayerScore", playerScore);
        PlayerPrefs.Save();
    }

    public void LoadNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
