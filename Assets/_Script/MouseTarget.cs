using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseTarget : MonoBehaviour
{
    
    public Vector3 MouseTargetPos(LayerMask layer)
    {
        Ray ray;
        if (Application.platform == RuntimePlatform.Android)
        {
             ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (GestureManager.Instance.IsTouchOverUIObject()) return Vector3.zero;

        }
        else 
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        Physics.Raycast(ray, out RaycastHit hit,Mathf.Infinity,layer, QueryTriggerInteraction.Collide);
        return (hit.collider == null) ? Vector3.zero : hit.point;
        
    }


}
