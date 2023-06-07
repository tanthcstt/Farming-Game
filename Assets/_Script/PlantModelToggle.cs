using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantModelToggle : MonoBehaviour
{
    public int CurrentLevel { get; private set; }
/*    private void Start()
    {
        foreach (Transform model in transform)
        {
            model.gameObject.SetActive(false);
        }
    }
*/
    public void SetModelByLevel(int level)
    {
        SetModel(level);
        SetLevel(level);
    }
    private void SetLevel(int level)
    {
        CurrentLevel = level;
    }
    private void SetModel(int level)
    {
        transform.GetChild(CurrentLevel).gameObject.SetActive(false);
        transform.GetChild(level).gameObject.SetActive(true);
    }
}
