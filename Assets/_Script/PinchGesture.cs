using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchGesture :MonoBehaviour
{
    private Vector2[] prevTouches = new Vector2[2];
    private Vector2[] currTouches = new Vector2[2];
    [SerializeField] private RectTransform joyStickTransform;
   
    public float PinchMagnitude { get; private set; }

    private void Update()
    {
        if (Input.touchCount >= 2 )
        {
            SetPinchMagnitude();
        }

    }
    private void SetPinchMagnitude()
    {
        // get current touches
        int validTouch = 0;
        foreach (Touch touch in Input.touches)
        {
            if (IsValidTouch(touch) && validTouch < 2)
            {
                currTouches[validTouch] = touch.position;
                validTouch++;
            }
        }

        if (validTouch < 2)
        {
            PinchMagnitude = 0;
            return;
        }

        PinchMagnitude = Vector2.Distance(prevTouches[0], prevTouches[1]) - Vector2.Distance(currTouches[0], currTouches[1]);
        PinchMagnitude = -Mathf.Clamp(PinchMagnitude, -1, 1);

        // set prev = current
        Array.Copy(currTouches, prevTouches, 2);
    }

    // a touch is valid if it outside joystick
    private bool IsValidTouch(Touch touch)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(joyStickTransform,touch.position))
        {
            return false;
        }
        return true;
    }

}
