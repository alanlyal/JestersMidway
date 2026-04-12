[System.Serializable]
public class GameData
{
    public string fileName;
    public string sceneName;

    //Achievements Data
    public int jumpsInGame;

    // Default values for a brand new game
    public GameData()
    {
        this.fileName = "Menu";
        this.sceneName = "Level1";
    }
}