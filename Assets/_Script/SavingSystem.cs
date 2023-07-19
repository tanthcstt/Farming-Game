using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public static class SavingSystem
{
    public static int CurrentWorldID  { get; private set; }
  
    public static void Save(GameData gameData)
    {      
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(FileManager.GetPath(CurrentWorldID), jsonData);
    }

    public static GameData Load()
    {
        string path = FileManager.GetPath(CurrentWorldID);
        string jsonData = File.ReadAllText(path);
        GameData worldData = JsonUtility.FromJson<GameData>(jsonData);
        return worldData;
    }

    private static string GetPath()
    {
        return Path.Combine(Application.persistentDataPath, "data.json");
    }

    public static void SetWorldID(int ID)
    {
        CurrentWorldID = ID;
    }
    public static bool IsFileExist()
    {
      
        return File.Exists(GetPath());
    }

   

}
