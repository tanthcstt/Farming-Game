using System.Collections;
using System.Collections.Generic;
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
            GameObject worldBtn = Instantiate(worldSelectionButtonPrefab, worldSelectionContent);
            if (worldBtn.TryGetComponent<Button>(out Button btn))
            {
                btn.onClick.AddListener(delegate { 
                    LoadScenceManager.Instance.LoadWorld(worldBtn.transform.GetSiblingIndex()); 
                });
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
