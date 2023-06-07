using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Player : MonoBehaviour
{
    private Animator controller;
    public PlayerMovement playerMovement;
    public readonly float CollectingTime = 3f;

    private enum State
    {
        Idle,
        Walking,
        Collecting,
    }
    private State currentState = State.Idle;    

    private void Awake()
    {
        controller = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(SwitchState());
        PerformStateAction();
    }

    // set state
    private IEnumerator SwitchState()
    {
        switch(currentState)
        {
            case State.Idle:
                if (playerMovement.IsWalking())
                {
                    currentState = State.Walking;
                } else if (Input.GetKeyDown(InputManager.Instance.interactingKey))
                {
                    currentState = State.Collecting;
                }
                break;

            case State.Walking:
                if (!playerMovement.IsWalking())
                {
                    currentState = State.Idle;
                }
                break ; 

            case State.Collecting:             
                yield return new WaitForSeconds(CollectingTime);    
                currentState = State.Idle;
                break ;
        }
    }

    // perform specific action for state
    private void PerformStateAction()
    {
        switch(currentState)
        {
            case State.Idle:
                controller.SetBool("isWalking", false);
                controller.SetBool("isCollecting", false);
                break;

            case State.Walking:
                controller.SetBool("isWalking", true);
                break;

            case State.Collecting:
                controller.SetBool("isCollecting", true);
                break;
        }
    }
}
