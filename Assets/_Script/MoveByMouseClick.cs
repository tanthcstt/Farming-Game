using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class MoveByMouseClick : PlayerMovement
{
    protected Vector3 targetPosition;
    [SerializeField] private RectTransform joystick;
    
    
    public override void Move()
    {
      
        // Mouse click for Windows and touch for Android
        bool isValidInput;
        if (Application.platform == RuntimePlatform.Android)
        {
            isValidInput = (Input.touchCount > 0 && GestureManager.Instance.IsValidTouch(joystick, Input.GetTouch(0)));
            if (!isValidInput) return;
           
        }
        else
        {
            isValidInput = Input.GetMouseButtonDown(1);
        }
       
        if (!isValidInput)
        {
            return;
        }
      

        var targetObj = TargetManager.Instance.GetMovingTarget();
        if (targetObj == null)
        {
            return;
        }
      
        targetPosition = targetObj.transform.position;

        if (!IsOnNavMeshSurface(targetPosition))
        {
            targetPosition = NearestPosition(targetPosition);
        }
        if (targetPosition == Vector3.zero)
        {
            return;
        }

        // Check for valid position on the NavMesh surface
        if (!NavMesh.SamplePosition(targetPosition, out _, .2f, NavMesh.AllAreas))
        {
            return;
        }
        // set offset 
        agent.stoppingDistance = ((BuildManager.Instance.currentState != BuildManager.BuildState.unActive) ? 10f : 0f);
        // Move to the target position
        agent.SetDestination(targetPosition);
    }

    private bool IsOnNavMeshSurface(Vector3 targetPos)
    {
        return NavMesh.SamplePosition(targetPos, out _,0.1f, NavMesh.AllAreas);
    }
    private Vector3 NearestPosition(Vector3 targetPos)
    {
        NavMeshHit hit;
        NavMesh.SamplePosition(targetPos,out hit, 20f, NavMesh.AllAreas);   
        return hit.position;
    }

   
}
