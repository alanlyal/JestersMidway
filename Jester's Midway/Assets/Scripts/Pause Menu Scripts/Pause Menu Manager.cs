
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Settings;
    public GameObject Main;
    public void ResumeGame()
    {
        Main.SetActive(false);
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("menu");
    }
    public void OpenSettings()
    { 
        Settings.SetActive(true);
        Main.SetActive(false);
    }
    public void CloseSettings()
    {
        Settings.SetActive(false);
        Main.SetActive(true);
    }
}
