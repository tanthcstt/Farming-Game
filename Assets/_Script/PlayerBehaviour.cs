using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviour: MonoBehaviour
{
    protected Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GameObject.Find("Player/Model").GetComponent<Animator>();
        if (playerAnimator == null) Debug.Log("null");
    }

    public abstract void UpdateBehaviour(PlayerBehaviourManager manager);


}
