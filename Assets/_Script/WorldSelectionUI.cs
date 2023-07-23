using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelectionUI : MonoBehaviour
{
    [SerializeField] protected GameObject worldSelectionButtonPrefab;
    [SerializeField] protected Transform worldSelectionContent;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        LoadWorldSelectionUI(); 
    }
    protected void LoadWorldSelectionUI()
    {
        ResetSelectionUI();

        for (int i = 0; i < FileManager.FilePaths.Count; i++)
        {
            // load world button
            GameObject worldBtn = Instantiate(worldSelectionButtonPrefab, worldSelectionContent);
            int worldID = worldBtn.transform.GetSiblingIndex();

            if (worldBtn.TryGetComponent<Button>(out Button btn))
            {
                btn.onClick.AddListener(delegate { 
                    LoadScenceManager.Instance.LoadWorld(worldID); 
                });
            }
            // delete world button
            GameObject deleteButton = worldBtn.transform.Find("Delete").gameObject;
            if (deleteButton.TryGetComponent<Button>(out Button delete))
            {
                delete.onClick.AddListener(delegate
                {
                    SavingSystem.DeleteWorld(worldID);
                    LoadWorldSelectionUI();
                });
            }
           

            TextMeshProUGUI btnText = worldBtn.GetComponentInChildren<TextMeshProUGUI>();
          
            if (btnText)
            {
                string path = Application.persistentDataPath;
                btnText.text = FileManager.GetFileName(worldID);
            }

        }
    }

    protected void ResetSelectionUI()
    {

        int childCount = worldSelectionContent.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Transform child = worldSelectionContent.GetChild(i);
            child.SetParent(null);
            Destroy(child.gameObject);
        }

    }

  
}
