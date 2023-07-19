using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; private set; }
    [SerializeField] protected List<GameObject> poolingPrefabs = new List<GameObject>();
    public Transform poolTransform;
    [SerializeField] protected int initNumber = 1;
    protected Dictionary<string, Queue<GameObject>> poolingData = new Dictionary<string, Queue<GameObject>>();
    private void Awake()
    {
        Instance = this;
        Init();
    }



    protected void Init()
    {
        foreach (GameObject prefab in poolingPrefabs)
        {
            Queue<GameObject> queue = new Queue<GameObject>();
            poolingData.Add(prefab.tag, queue);

            for (int i = 0; i < initNumber; i++)
            {
                GameObject obj = Instantiate(prefab, poolTransform);
                obj.SetActive(false);
                poolingData[obj.tag].Enqueue(obj);               
            }
        }      
    }
    public void Despawn(GameObject obj)
    {
        obj.transform.SetParent(poolTransform, false);
        poolingData[obj.tag].Enqueue(obj);
        obj.SetActive(false);
    }

   
    public GameObject Spawn(GameObject prefab, Vector3 pos = default(Vector3),bool isReturnObject = false)
    {
        GameObject obj;
        if (poolingData[prefab.tag].Count > 0)
        {
            obj = poolingData[prefab.tag].Dequeue();
        } else
        {
            obj = Instantiate(prefab, poolTransform);
            poolingData[prefab.tag].Enqueue(obj);

        }

        obj.SetActive(true);
        obj.transform.position = pos;
        return isReturnObject ? obj : null; 

    }
    
    public GameObject GetPoolingPrefab(string tag)
    {
        foreach(GameObject item in poolingPrefabs)
        {
            if (item.tag == tag) return item;   
        }
        Debug.Log("can not find pooling prefab " + tag);
        return null;
    }
}
