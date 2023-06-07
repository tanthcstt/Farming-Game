using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelectingEffect : MonoBehaviour
{
    public Tilemap tileMap;    
    public GameObject tileUI;

    private void Update()
    {
        SelectingEffectController();
    }
    private void SelectingEffectController()
    {
        GameObject mouseTarget = TargetManager.Instance.GetTileMapTarget();
        if (mouseTarget == null) return;
        Vector3 worldPos = GetPosition(mouseTarget.transform);        
        SetPosition(worldPos);
    }
    private Vector3 GetPosition(Transform mouseTargetTransform)
    {
        // convert world position to tilemap position
        Vector3Int tileMapPos = tileMap.WorldToCell(mouseTargetTransform.position);
        // convert tilemap pos to world pos to set pos        
        Vector3 worldPos =  tileMap.CellToWorld(tileMapPos);
        // 0.5 is offset for the obj fit in rectagle
        worldPos.x += 0.5f;
        worldPos.z += 0.5f;
        worldPos.y = 0.5f;
        return worldPos;

    }
    private void SetPosition(Vector3 pos)
    {
        tileUI.transform.position = pos;
    }
}
