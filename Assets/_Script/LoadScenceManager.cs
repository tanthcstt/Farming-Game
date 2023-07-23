using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScenceManager : MonoBehaviour
{
    public static LoadScenceManager Instance { get; private set; }
    [SerializeField] protected GameObject loadingUI;
    private Slider loadingSlider;

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
        loadingSlider = loadingUI.GetComponentInChildren<Slider>();
        loadingUI.SetActive(false);

       
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
        StartCoroutine(LoadScene());
    }

    public void LoadWorld(int worldIndex)
    {
        SavingSystem.SetWorldID(worldIndex);
        StartCoroutine(LoadScene());
    }
    public void Exit()
    {
        Application.Quit();
    }
    public IEnumerator LoadScene()
    {
        loadingUI.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Main");
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f); 
            loadingSlider.value = progress; 

            yield return null;  
        }

    }
   

  

}
