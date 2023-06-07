using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class CraftingFormula
{
    public ScriptableObject_Items item;
    public int amount;
}

[CreateAssetMenu(fileName ="Construction", menuName ="Construction/New Construciton")]
public class ScriptableObject_Construction : ScriptableObject
{
    public string constructionName;
    public int type;
    public Sprite sprite;
    public List<CraftingFormula> materials;
   
    public GameObject prefab;
    
}
