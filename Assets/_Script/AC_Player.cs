using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AC_Player : MonoBehaviour
{
    private Animator controller;
    public PlayerMovement playerMovement;
    public PlayerAbility playerBehaviour;
    public readonly float CollectingTime = 3f;
    public readonly float MiningTime = 3f;
    public readonly float HoeingTime = 3f;

    [Header("Animation tools")]
    public GameObject hoe;
    public GameObject pickaxe;

    private bool isEndState = true;

    public enum State
    {
        Idle,
        Walking,
        Collecting,
        Hoeing,
        Mining,
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

            case State.Mining:
                isEndState = false;
                yield return new WaitForSeconds(MiningTime);
                isEndState = true;
                currentState = State.Idle;
                break;
            case State.Hoeing:
                isEndState = false;
                yield return new WaitForSeconds(HoeingTime);
                isEndState = true;
                currentState = State.Idle;
                break;
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
                controller.SetBool("isMining", false);
                controller.SetBool("isHoeing", false);
                hoe.SetActive(false);
                pickaxe.SetActive(false);
                break;

            case State.Walking:
                controller.SetBool("isWalking", true);
                break;

            case State.Collecting:
                controller.SetBool("isCollecting", true);
                break;

            case State.Mining:
                controller.SetBool("isMining", true);
                pickaxe.SetActive(true);
                break;

            case State.Hoeing:
                controller.SetBool("isHoeing", true);
                hoe.SetActive(true);
                break ;
        }
    }

    public IEnumerator WaitForAnimationEnd(State state, Action callback)
    {
        if (currentState == state) yield break;
        currentState = state;
        while(currentState == state)
        {
            yield return null;  
        }
        callback.Invoke();
    }
}
