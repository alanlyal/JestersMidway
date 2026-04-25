using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public GameObject settingsPanel;

    private bool isPaused = false;
    void Awake()
    {
        Time.timeScale = 1f;

        if (pauseCanvas != null) pauseCanvas.SetActive(false);
        if (settingsPanel != null) settingsPanel.SetActive(false);

#if UNITY_ANDROID
        Cursor.visible = true;
#else
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }
    void Update()
    {
#if !UNITY_ANDROID
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
                ResumeGame();
            else
                OpenPauseMenu();
        }
#endif
    }
    public void OpenPauseMenu()
    {
        isPaused = true;
        if (pauseCanvas != null)
            pauseCanvas.SetActive(true);
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
        Time.timeScale = 0f;

#if !UNITY_ANDROID
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
#endif
    }
    public void ResumeGame()
    {
        isPaused = false;
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
        Time.timeScale = 1f;

#if !UNITY_ANDROID
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
    public void OpenSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(true);
        if (pauseCanvas != null)
            pauseCanvas.SetActive(false);
    }
    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);
        if (pauseCanvas != null)
            pauseCanvas.SetActive(true);
    }
}