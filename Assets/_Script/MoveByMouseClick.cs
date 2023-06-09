using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveByMouseClick : PlayerMovement
{
    protected Vector3 targetPosition;
   
    public override void Move()
    {
       
        if (!Input.GetMouseButtonDown(1)) return;
        // set target position
        if (TargetManager.Instance.GetMovingTarget() == null) return;   
        targetPosition = TargetManager.Instance.GetMovingTarget().transform.position;
        if (!IsOnNavMeshSurface(targetPosition))
        {
            targetPosition = NearestPosition(targetPosition);
        }
        if (targetPosition == Vector3.zero) return;
        // check for valid position on navmesh surface
        if (!NavMesh.SamplePosition(targetPosition, out _, .2f, NavMesh.AllAreas)) return;
        // move by target
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
