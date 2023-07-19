using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileManager 
{
    public static List<string> FilePaths;

   
    public static void AddFilePath(string path)
    {
        FileManager.FilePaths.Add(path);
    }

    public static string NewFilePath()
    {
        string newPath = Path.Combine(Application.persistentDataPath, "WorldData" + FilePaths.Count.ToString() + ".json");
        FilePaths.Add(newPath);
        return newPath;
    }
    public static void FilePathInit()
    {
        FilePaths = new List<string>(Directory.GetFiles(Application.persistentDataPath));
    }

    public static string GetPath(int WorldID)
    {
        return FilePaths[WorldID];  
    }
}
