using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWaterControll : MonoBehaviour
{
    private Transform roto;
    private readonly float rotateSpeed = 30f;
    private readonly Vector3 wateringRange = new(8.5f, 3f, 8.5f);
    private void Awake()
    {
        roto = transform.Find("Model/Rotate");
    }
    private void Start()
    {
        SetState(true); 
    }
    private void Update()
    {
        if (roto.gameObject.activeSelf)
        {
            RotateRoto();
            Watering();
        }
    }
    // set active for roto
    // make roto rotate
    private void SetState(bool state)
    {
        roto.gameObject.SetActive(state);   
       
    }
    private void RotateRoto()
    {
        roto.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }

    private void Watering()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, wateringRange / 2f, Quaternion.identity,LayerMask.GetMask("Plant"));
        
        foreach(Collider coll in colliders)
        {
            if (coll.gameObject.TryGetComponent(out PlantGrowing plantGrowing))
            {
                plantGrowing.Watering();
                Debug.Log(coll.gameObject.name);
            }
        }
    }
   /* void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, wateringRange);
    }*/


}
