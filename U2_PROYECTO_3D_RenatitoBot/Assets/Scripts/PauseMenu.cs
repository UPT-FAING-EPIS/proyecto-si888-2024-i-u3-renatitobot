using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }

   
    private void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    
    private void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    
    private void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
