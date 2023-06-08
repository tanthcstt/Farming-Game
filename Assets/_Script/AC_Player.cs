using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AC_Player : MonoBehaviour
{
    private Animator controller;
    public PlayerMovement playerMovement;
    public PlayerAbility playerBehaviour;
    public readonly float CollectingTime = 3f;

    private bool isEndState = true;

    public enum State
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
        if (isEndState)
        {
            StartCoroutine(SwitchState());
        }
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
                } 
                break;

            case State.Walking:
                if (!playerMovement.IsWalking())
                {
                    currentState = State.Idle;
                }
              
                break ; 

            case State.Collecting:
                isEndState = false;
                yield return new WaitForSeconds(CollectingTime);    
                isEndState = true;  
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

    public void SetState(State state)
    {
        currentState = state;
    }
    public State GetState()
    {
        return currentState;
    }
}
