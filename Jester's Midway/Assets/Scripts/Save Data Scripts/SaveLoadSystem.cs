using UnityEngine;

public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
{
    private IDataService fileDataService;
    public GameData currentData;

    protected override void Awake()
    {
        base.Awake(); // Sets up SaveLoadSystem.Instance

        // Handshake with the File Service and your Serializer
        fileDataService = new FileDataService(new JsonSerializer());
    }

    public void LoadGame(string gameName)
    {
        // Try to load the file
        GameData data = fileDataService.Load(gameName);

        if (data == null)
        {
            // If the file doesn't exist yet, create a new one!
            currentData = new GameData();
            currentData.fileName = gameName;
            Debug.Log("No save found. Created new GameData.");
        }
        else
        {
            currentData = data;
            Debug.Log("Game Loaded: " + gameName);
        }
    }

    public void SaveGame()
    {
        if (currentData != null)
        {
            fileDataService.Save(currentData);
            Debug.Log("Game Saved!");
        }
    }
}