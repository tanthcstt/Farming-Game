using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    public Transform playerEyes;
    public GameObject ForwardTarget(LayerMask layer)
    {     
        Ray ray = new Ray(playerEyes.position, playerEyes.forward);
        Physics.Raycast(ray, out RaycastHit hit, 3f,layer);
        return (hit.collider == null) ? null : hit.collider.gameObject;
    }


    public GameObject DownwardTarget(LayerMask layer)
    {
        Ray ray = new Ray(playerEyes.position, -playerEyes.up);
        Physics.Raycast(ray, out RaycastHit hit, 3f, layer, QueryTriggerInteraction.Collide);
        return (hit.collider == null) ? null : hit.collider.gameObject;
    }

    public GameObject TargetToPoint(Vector3 point, LayerMask layer) 
    {
        Ray ray = new Ray(playerEyes.position, point - playerEyes.position);
        Physics.Raycast(ray, out RaycastHit hit, 3f, layer, QueryTriggerInteraction.Collide);
        return (hit.collider == null) ? null : hit.collider.gameObject;
    }
}
