using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Camera Zoom")] //  zoom by change distance from player to camera
    private readonly float minDistance = 10f;
    private readonly float maxDistance = 70f;  

    [Header("Camera Follow")]
    private readonly float smoothSpeed = 0.05f;
    public Transform playerTransform;
    public Vector3 offset; // from player to camera;
    private Vector3 targetPos;
    private Vector3 smoothedPos;

    private void Update()
    {
        FollowByPlayerPosition();
        CameraZoom();   
    }
    private void FollowByPlayerPosition()
    {
        targetPos = playerTransform.position + offset;
        smoothedPos = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = smoothedPos;
    }



    private void CameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");        
        if (scroll != 0.0f)
        {
            Vector3 increaseAxis = new Vector3(0, -1, 1);
            Vector3 newOffset = offset + ((scroll > 0) ? increaseAxis * 2 : -increaseAxis * 2);
            if (Vector3.Distance(playerTransform.position + newOffset, playerTransform.position) >= maxDistance) return;
            if (Vector3.Distance(playerTransform.position + newOffset, playerTransform.position) <= minDistance) return;
            offset = newOffset;
            
        }
        
    }


}
