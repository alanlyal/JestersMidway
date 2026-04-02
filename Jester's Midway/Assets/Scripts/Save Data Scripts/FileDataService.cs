using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataService : IDataService
{
    private ISerializer serializer;
    private string dataPath;
    private string fileExtension = ".json";

    public FileDataService(ISerializer serializer)
    {
        this.serializer = serializer;
        dataPath = Application.persistentDataPath;
    }

    private string GetPathFile(string fileName) => Path.Combine(dataPath, fileName + fileExtension);

    public void Save(GameData data, bool overwrite = true)
    {
        string fileLocation = GetPathFile(data.fileName);
        if (!overwrite && File.Exists(fileLocation)) return;
        File.WriteAllText(fileLocation, serializer.Serialize(data));
    }

    public GameData Load(string fileName)
    {
        string fileLocation = GetPathFile(fileName);
        // FIX: Return null instead of throwing an Exception
        if (!File.Exists(fileLocation)) return null;
        return serializer.Deserialize<GameData>(File.ReadAllText(fileLocation));
    }

    public void Delete(string name) { if (File.Exists(GetPathFile(name))) File.Delete(GetPathFile(name)); }
    public IEnumerable<string> ListSaves() { yield break; } // Simplified for now
}