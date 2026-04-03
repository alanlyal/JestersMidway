using UnityEngine;
using UnityEngine.UI;

public class Menu : PersistentSingleton<Menu>
{
    [SerializeField] private Button loadBtn;

    private void Start()
    {
        if (loadBtn == null) return;

        loadBtn.onClick.AddListener(() =>
        {
            // CRITICAL: Use 'Instance' (Capital I) 
            if (SaveLoadSystem.Instance != null)
            {
                SaveLoadSystem.Instance.LoadGame("Menu");
            }
        });
    }
}