using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnviromentObjectData
{
    // posisiton
    public string objectTagName;
    public float x = 0;
    public float y = 0;
    public float z = 0;
    // rotation
    public float xRotation = 0;
    public float yRotation = 0;
    public float zRotation = 0;
    // planting
    public int growingLevel = 0;
     

}

[System.Serializable]
public class GameData
{

    public int coin = 99;
    public float[] playerPosition = {62f,0.5f,28f}; // default position
   
    // inventory
    public List<string> invenName = new List<string>();
    public List<int> invenAmount = new List<int>();

    //enviroment
    public List<EnviromentObjectData> enviroment = new List<EnviromentObjectData>();  
   
}
