using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    private float startGrowingTime;
    private bool isWatered = false; 
    private PlantData plantData;
    public int Level { get; private set; }

    private PlantModelToggle plantModelToggle;
    private void OnEnable()
    {
        StartGrowing();
    }
    public void StartGrowing(int level = 0)
    {
        SetLevel(level);
        SetStartTime(Time.realtimeSinceStartup);
        plantModelToggle.SetModelByLevel(level);
    }
    private void Awake()
    {
       
        LoadComponent();
    }
    private void LoadComponent()
    {
        plantData = GetComponent<PlantData>();       
        plantModelToggle = GetComponentInChildren<PlantModelToggle>();  
    }
   

    private void FixedUpdate()
    {
        Growing();
       
    }
 
    private void Growing()
    {
        if (Level >= 2) return;
        if (!IsEnoughTime()) return;
        if (!isWatered) return;

        SetLevel(++Level);
        plantModelToggle.SetModelByLevel(Level);
        SetStartTime(Time.realtimeSinceStartup);
    }

    
    private bool IsEnoughTime()
    {
        return Time.realtimeSinceStartup - startGrowingTime >= plantData.generalData.growTime;
    }
    private void SetStartTime(float time)
    {
        startGrowingTime = time;
    }
    public void SetLevel(int level)
    {
        Level = level;
    }
    public void Watering()
    {
        isWatered = true;
    }

    
}
