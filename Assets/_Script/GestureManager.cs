using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public  class GestureManager : MonoBehaviour
{
    public static GestureManager Instance { get; private set; }
   
    private void Awake()
    {
        Instance = this;    
    }
   
    public bool IsValidTouch(RectTransform invalidRange, Touch touch)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(invalidRange, touch.position))
        {
            return false;
        }
        return true;
    }
    public bool IsTouchOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
