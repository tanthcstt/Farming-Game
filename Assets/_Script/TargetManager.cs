using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }
  
    private GameObject destroyableObjTarget;
    private Vector3 tilemapTargetPos;
 
    private readonly string[] destroyableLayer = { "Destroyable_Env"};    
    private readonly float targetRange = 3f;

    public PlayerTarget playerTarget;
    public MouseTarget mouseTarget;

    private void Awake()
    {
        Instance = this;      
        playerTarget = GetComponentInChildren<PlayerTarget>();
        mouseTarget = GetComponentInChildren<MouseTarget>();
    }
    private void Update()
    {
     
    }
    // get target to tilemap to move 
    public Vector3 GetMovingTarget()
    {       
        return mouseTarget.MouseTargetPos(LayerMask.GetMask("Base"));
    }

    public GameObject GetInteractiveTarget(LayerMask layer)
    {
        return playerTarget.ForwardTarget(layer);
    }
  
    public bool IsInTargetRange(GameObject target)
    {        
        return (Vector3.Distance(target.transform.position, transform.root.position) <= targetRange);
    }



    

    public Vector3 GetTileMapTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            tilemapTargetPos = mouseTarget.MouseTargetPos(LayerMask.GetMask("Base"));
        } else if (InputManager.Instance.IsMovingKeyPress())
        {
            tilemapTargetPos = playerTarget.DownwardTarget(LayerMask.GetMask("Base"));
        }
        return tilemapTargetPos;
    }

   

}
