using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad Instance { get; private set; }    
   

    [SerializeField]protected CoinManager coinManager;
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected PlayerMovement playerMovement;

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
    }
    private void Start()
    {
        LoadToWorld(SavingSystem.Load()); 
       
    }
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.I)) { coinManager.UpdateCoin(5); }
    }

    public void Save()
    {
        GameData gameData = new GameData(); 
        // save coin
        gameData.coin = CoinManager.Instance.Coin;

        // save position
        gameData.playerPosition[0] = playerTransform.position.x;
        gameData.playerPosition[1] = playerTransform.position.y;
        gameData.playerPosition[2] = playerTransform.position.z;

        //save inventory
        gameData.invenName.Clear();
        gameData.invenAmount.Clear();
        List<GeneralItemData> inventoryList = InventoryManager.Instance.inventoryStorage.InventoryList;
        foreach (GeneralItemData item in inventoryList) 
        {
            if (item == null) continue;

            string itemTagName = item.gameObject.tag;
            int amount = item.count;

            gameData.invenName.Add(itemTagName);
            gameData.invenAmount.Add(amount);
        }

        // save enviroment 
        gameData.enviroment.Clear();
        foreach (Transform objInPool in ObjectPooling.Instance.poolTransform)
        {
            if (!objInPool.gameObject.activeSelf) continue;

            EnviromentObjectData objData = new EnviromentObjectData();

            objData.objectTagName = objInPool.gameObject.tag;

            objData.x = objInPool.position.x;
            objData.y = objInPool.position.y;
            objData.z = objInPool.position.z;

            objData.xRotation = objInPool.rotation.eulerAngles.x;
            objData.yRotation = objInPool.rotation.eulerAngles.y;
            objData.zRotation = objInPool.rotation.eulerAngles.z;

            if (objInPool.gameObject.TryGetComponent<PlantGrowing>(out PlantGrowing growing))
            {
                objData.growingLevel = growing.Level;
            }

          


            gameData.enviroment.Add(objData);
        }


        //
        SavingSystem.Save(gameData);
        Debug.Log("saved");
    }
    public void LoadToWorld(GameData gameData)
    {
        // load coin       
        coinManager.UpdateCoin(gameData.coin);

        // load position
        Vector3 playerPosition = new Vector3(gameData.playerPosition[0], gameData.playerPosition[1], gameData.playerPosition[2]);
      
      
        playerTransform.position = playerPosition;
        playerMovement.EnableAgent();
        playerMovement.SetPlayerDestination(playerPosition);
        
        // load inventory
        for (int  i= 0; i < gameData.invenName.Count; i++)
        {
            string itemTagName = gameData.invenName[i];
            int itemCount = gameData.invenAmount[i];

            GameObject prefab = ObjectPooling.Instance.GetPoolingPrefab(itemTagName);
            if (prefab == null) continue;

            GameObject inventoryItem = ObjectPooling.Instance.Spawn(prefab,Vector3.zero,true);

            for (int j = 0; j < itemCount; j++)
            {
                InventoryManager.Instance.PickUpItem(inventoryItem);
            }
        }
        
        //load enviroment
        foreach (EnviromentObjectData envData in gameData.enviroment)
        {
            GameObject prefab = ObjectPooling.Instance.GetPoolingPrefab(envData.objectTagName);
            if (prefab == null) continue;

            Vector3 envPos = new Vector3(envData.x,envData.y,envData.z);
            Vector3 rotation = new Vector3(envData.xRotation, envData.yRotation, envData.zRotation);    

            GameObject envObj = ObjectPooling.Instance.Spawn(prefab, envPos, true);
            envObj.transform.rotation = Quaternion.Euler(rotation);
     
            if (envObj.TryGetComponent<PlantGrowing>(out PlantGrowing growing))
            {
                growing.StartGrowing(envData.growingLevel);
            }
           

        }



    }
}
