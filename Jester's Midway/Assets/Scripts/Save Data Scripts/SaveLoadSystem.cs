using UnityEngine;

public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem>
{
    private IDataService fileDataService;
    public GameData currentData;

    protected override void Awake()
    {
        base.Awake(); 
        Debug.Log("SAVE PATH: " + Application.persistentDataPath);
        
        fileDataService = new FileDataService(new JsonSerializer());
    }

    public void LoadGame(string gameName)
    {
    
        GameData data = fileDataService.Load(gameName);

        if (data == null)
        {
          
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