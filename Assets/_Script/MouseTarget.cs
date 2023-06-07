using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTarget : MonoBehaviour
{
    
    public GameObject MouseTargetObj(LayerMask layer)
    {       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,layer, QueryTriggerInteraction.Collide);
        return (hit.collider == null) ? null : hit.collider.gameObject;
        
    }
}
