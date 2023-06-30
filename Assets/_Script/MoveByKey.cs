using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

//player move by WASD key
public class MoveByKey : PlayerMovement
{
    
    private float horizontal;
    private float vertical;
    private Vector3 direction;
    [SerializeField] private FixedJoystick joyStick;
    public override void Move()
    {

        /*horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");*/
        
        if (true)
        {
            horizontal = joyStick.Horizontal;
            vertical = joyStick.Vertical;
        }

        direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude <= 0.1f) return;
       
        Vector3 target = transform.root.position + direction;

       

        if (!NavMesh.SamplePosition(target, out NavMeshHit _, 0.2f, NavMesh.AllAreas)) return;
        agent.SetDestination(target);
        ChangePlayerRotation(target);
    }
  
}
