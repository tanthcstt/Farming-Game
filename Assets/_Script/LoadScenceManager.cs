using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScenceManager : MonoBehaviour
{
    public static LoadScenceManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        FileManager.FilePathInit();
    }

    public void NewWorld()
    {
        // create empty gameData
        GameData gameData = new GameData();

        // create new file
        string filePath = FileManager.NewFilePath();
        int worldID = FileManager.FilePaths.Count - 1;
        SavingSystem.SetWorldID(worldID);
        // save to file
        SavingSystem.Save(gameData);

        LoadScene();      
        
    }

    public void LoadWorld(int worldIndex)
    {
        SavingSystem.SetWorldID(worldIndex);
        LoadScene();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
   

  

}
