using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class pause : MonoBehaviour
{
    public GameObject container;

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            container.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        container.SetActive(false);
        Time.timeScale = 1f;
    }

    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menuinicial");
    }

    public void RestartGame(string fase1)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("fase1");
    }
}