using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas; 
    public GameObject settingsPanel;
    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (pauseCanvas.activeSelf)
            {
                ResumeGame();
            }
            else
            {
                OpenPauseMenu();
            }
        }
    }
    public void OpenPauseMenu()
    {
        pauseCanvas.SetActive(true);
        settingsPanel.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void QuitGame()
    {
        Time.timeScale = 1.0f; 
        SceneManager.LoadScene("menu");
    }
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        pauseCanvas.SetActive(false);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pauseCanvas.SetActive(true);
    }
}