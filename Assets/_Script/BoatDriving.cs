using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;

public class BoatDriving : MonoBehaviour
{
    private CameraControl cameraControl;
    public float maxSpeed = 20f;    

    public float acceleration = 15f; // Acceleration when moving  

    public float turnSpeed = 50f;
    private bool isGetOn = false;   
    
    private Transform motorTransform;
    private ParticleSystem[] particleSystems;
    private Bouyancy bouyancy;
    private GameObject player;
 
    private Rigidbody rb;
    private void Start()
    {
        LoadComponent();    
        ToggleParticleSystems(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) GetOff();
    }
    private void LoadComponent()
    {
        rb = GetComponent<Rigidbody>();
        cameraControl = Camera.main.gameObject.GetComponent<CameraControl>();
        motorTransform = transform.Find("Motor");
        Transform effectTransform = transform.Find("Effect");
        particleSystems = new ParticleSystem[effectTransform.childCount];
        bouyancy = GetComponent<Bouyancy>();
        for (int i = 0; i < effectTransform.childCount; i++)
        {
            if (effectTransform.GetChild(i).TryGetComponent(out ParticleSystem particle))
            {
                particleSystems[i] = particle;
            }
        }
    }
    public void GetOn(GameObject player)
    {
        isGetOn = true;
        this.player = player;   
        player.SetActive(false);
        cameraControl.ChangeFollowing(transform);

    }
    public void GetOff()
    {
        // check for a valid position nearest
        Vector3 targetPos = NavMeshHelper.Instance.GetNearsetPosition(transform.position, 10f);
        if (targetPos != Vector3.zero)
        {
            this.player.SetActive(true);
            this.player.transform.position = targetPos;
            cameraControl.ChangeFollowing(player.transform);
            isGetOn = false;


        }
    }
    private void FixedUpdate()
    {
        if (isGetOn) Drive();
    }
    public void Drive()
    {
        // prevent boat fly infinitely
        if (bouyancy.IsAboveWater) return;

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Calculate the desired movement direction based on input
        Vector3 desiredVelocity = z * transform.forward;

        // Check if the boat is moving or not
        if (desiredVelocity.magnitude > 0)
        {
            // Apply acceleration to the boat's velocity
            if (rb.velocity.magnitude < maxSpeed)
            {

                //rb.velocity += desiredVelocity * acceleration *Time.fixedDeltaTime;
                rb.AddForceAtPosition(desiredVelocity * acceleration * maxSpeed * Time.fixedDeltaTime, motorTransform.position, ForceMode.Force);
            }

           
            ToggleParticleSystems(true);
        }
        else ToggleParticleSystems(false);

        // Rotate the boat
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * turnSpeed * x * Time.fixedDeltaTime);
        rb.MoveRotation(deltaRotation * rb.rotation);

    }
    private void ToggleParticleSystems(bool state)
    {
        foreach (ParticleSystem particle in particleSystems)
        {
            if (state)
            {
                particle.Play();
            }
            else particle.Stop();
        }
    }
}
