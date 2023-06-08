using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FenceDoorOpening : MonoBehaviour
{
    private Animator animator;
    private bool isOpening = false;
    private NavMeshObstacle obstacle;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        obstacle = GetComponent<NavMeshObstacle>();
    }


    public void ToggleDoor()
    {
        animator.SetTrigger("trgOpen");
        isOpening = !isOpening;
        if (isOpening)
        {
            // turn off navmesh obstacle
            obstacle.enabled = false;
        } else obstacle.enabled = true; 
    }

}
