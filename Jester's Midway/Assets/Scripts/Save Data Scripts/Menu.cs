using UnityEngine;
using UnityEngine.UI;

public class Menu : PersistentSingleton<Menu>
{
    [SerializeField] private Button loadBtn;

    private void Start()
    {
        if (loadBtn == null)
        {
            Debug.LogError("Load button not assigned in Menu!");
            return;
        }

        loadBtn.onClick.AddListener(() =>
        {
            if (SaveLoadSystem.instance == null)
            {
                Debug.LogError("SaveLoadSystem instance is missing!");
                return;
            }

            SaveLoadSystem.instance.LoadGame("Menu");
        });
    }
}