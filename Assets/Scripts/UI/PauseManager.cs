using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu, winPanel, GameOverPanel;
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        winPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            onPaused();
        }
    }

    void onPaused()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
