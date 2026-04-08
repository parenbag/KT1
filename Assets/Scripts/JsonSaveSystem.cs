using UnityEngine;
using System.IO;

public class JsonSaveSystem : ISaveSystem
{
    private string path = Application.persistentDataPath + "/save.json";

    public void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public GameData Load()
    {
        if (!File.Exists(path))
            return new GameData();

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<GameData>(json);
    }
}