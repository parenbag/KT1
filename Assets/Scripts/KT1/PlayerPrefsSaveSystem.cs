using UnityEngine;

public class PlayerPrefsSaveSystem : ISaveSystem
{
    public void Save(GameData data)
    {
        PlayerPrefs.SetFloat("score", data.score);
        PlayerPrefs.SetFloat("time", data.playTime);
        PlayerPrefs.Save();
    }

    public GameData Load()
    {
        GameData data = new GameData();
        data.score = PlayerPrefs.GetFloat("score", 0);
        data.playTime = PlayerPrefs.GetFloat("time", 0);
        return data;
    }
}