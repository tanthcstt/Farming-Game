using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshHelper : MonoBehaviour
{
    public static NavMeshHelper Instance { get; private set; } 
    private void Awake()
    {
        Instance = this;
    }

    public Vector3 GetNearsetPosition(Vector3 currentPos, float maxRange)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(currentPos, out hit, maxRange, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return Vector3.zero;
    }
}
