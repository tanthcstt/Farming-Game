using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Destroyable Enviroment Object", menuName ="Object/Destroyable Enviroment Onject")]
public class DestroyableEnvObj : ScriptableObject
{
    public GameObject dropItem;
    public GameObject remainingObject;
    public float timeToDestroy;
}
