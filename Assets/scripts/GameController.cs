using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public GameObject gameOver;
    public string nextLevel;

    [HideInInspector] public int totalApples;
    [HideInInspector] public int collectedApples;

    public static GameController instance;

    private void Awake()
    {
        instance = this;
    }

    public void RegisterApple()
    {
        totalApples++;
    }

    public void AppleCollected()
    {
        collectedApples++;

        if (totalApples > 0 && collectedApples >= totalApples)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        Invoke("LoadNextLevel", 0.5f);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame(string fase1)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("fase1");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuinicial");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("fase1");
    }
}