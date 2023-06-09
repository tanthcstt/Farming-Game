using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bouyancy : MonoBehaviour
{
    private Rigidbody rb;
    private Transform[] floaters;
  
    private float waterHeight = 0; // adjust water position.y = waterheight;
    public float floatingPower = 30f;

    public float waterDrag = 3f;
    public float waterAngularDrag = 1f;

    public float airDrag = 0f;
    public float airAngularDrag = 0.05f;
    public bool IsAboveWater { get; private set; }  // when the object completely above water
    private int floatersCount;
    private void Start()
    {
       LoadComponent(); 
    }
    private void LoadComponent()
    {
        rb = GetComponent<Rigidbody>();
        Transform floaterContent = transform.Find("Floaters");
        floaters = new Transform[floaterContent.childCount];
        for (int i = 0; i < floaterContent.childCount; i++)
        {
            floaters[i] = floaterContent.GetChild(i).transform;
        }
    }
    private void FixedUpdate()
    {
        floatersCount = 0;        
        foreach (Transform floater in floaters)
        {
            float distance = floater.position.y - waterHeight;
            if (distance < 0)
            {
                // object underwater
                rb.AddForceAtPosition(floatingPower * Mathf.Abs(distance) * Vector3.up, floater.position, ForceMode.Force);
                floatersCount++;                
            }
           
        }

        IsAboveWater = ((floatersCount > 0) ? false : true);

        SwitchState();
    }
    // change drag of water to air
    private void SwitchState()
    {
        if (floatersCount == floaters.Length)
        {
            rb.drag = waterDrag;
            rb.angularDrag = waterAngularDrag;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }
    }

}
