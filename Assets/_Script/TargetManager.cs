using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager Instance { get; private set; }
  
    private GameObject destroyableObjTarget;
    private GameObject tilemapTarget;
 
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
    public  GameObject GetMovingTarget()
    {
        return mouseTarget.MouseTargetObj(LayerMask.GetMask("Base"));
    }

  
    public bool IsInTargetRange(GameObject target)
    {        
        return (Vector3.Distance(target.transform.position, transform.root.position) <= targetRange);
    }



    /// <summary>
    ///     if player right click => target to this obj
    ///     if player moving by key => target forward
    ///      if player do nothing => return previous target
    ///     this function use private variable destroyableObjTarget to store previous target
    ///     this function must be called in update
    /// </summary>
    /// <returns></returns>
    public GameObject GetDestroyableObjTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            destroyableObjTarget = mouseTarget.MouseTargetObj(LayerMask.GetMask(destroyableLayer));
       
        } 
        else if (InputManager.Instance.IsMovingKeyPress())
        {
            destroyableObjTarget = playerTarget.ForwardTarget(LayerMask.GetMask(destroyableLayer));
        }
  
        return destroyableObjTarget;
    }
    // =======================================================

    public GameObject GetTileMapTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            tilemapTarget = mouseTarget.MouseTargetObj(LayerMask.GetMask("Base"));
        } else if (InputManager.Instance.IsMovingKeyPress())
        {
            tilemapTarget = playerTarget.DownwardTarget(LayerMask.GetMask("Base"));
        }
        return tilemapTarget;
    }



}
