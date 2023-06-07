using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Plant",menuName ="Plants/Create Plant")]
public class ScriptableObj_Plant : ScriptableObject
{
    public float plantID;
    public float growTime; // time for growing 1 level
    public GameObject seedPrefabs;
    public GameObject dropItem;
    public int seedPrice;
    // for UI
    public string plantName;
    public Sprite sprite;
 
}
