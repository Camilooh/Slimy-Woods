using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    public GameObject MainMenuPanel, SettingsPanel, CreditsPanel, InstructionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
    }
    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
    }
    public void OpenCredits()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(true);
        InstructionsPanel.SetActive(false);
    }
    public void CloseCredits()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
    }
    public void OpenInstructions()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(true);
    }
    public void CloseInstructions()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        CreditsPanel.SetActive(false);
        InstructionsPanel.SetActive(false);
    }
    public void OpenGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
