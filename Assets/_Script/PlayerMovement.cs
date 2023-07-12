using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows;


public abstract class PlayerMovement : MonoBehaviour
{
    protected float turnSpeed = 7f;

    protected NavMeshAgent agent;

    public bool IsForceStop { get; private set; }  

    private void Awake()
    {
        IsForceStop = false;
        agent = transform.root.GetComponent<NavMeshAgent>();
        if (agent == null) Debug.LogWarning("null NavMesh Agent");
        
    }
    private void Update()
    {
        if (!IsForceStop)
        {
            Move();
        }
         
      
    }

    public abstract void Move();
    protected void ChangePlayerRotation(Vector3 targetPos)
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.root.position);
        Quaternion playerRotation = Quaternion.Slerp(transform.root.rotation, targetRotation, turnSpeed * Time.deltaTime);
        transform.root.rotation = playerRotation;
    }

    public bool IsWalking()
    {
        return agent.velocity.magnitude > 0.001f;
    }
    public void ForceStop(bool state)
    {
        IsForceStop = state;
    }
   
   
}
