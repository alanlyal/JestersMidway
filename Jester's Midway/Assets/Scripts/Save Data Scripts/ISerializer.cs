using System.Collections;

public interface ISerializer
{
    string Serialize<T>(T obj); // This will recieve the obj and serialize it
    T Deserialize<T>(string json);
}
