using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviour: MonoBehaviour
{
    protected Animator playerAnimator;
    protected AC_Player AC_Player;
    protected PlayerMovement playerMovement;
    private void Start()
    {
        playerAnimator = GameObject.Find("Player/Model").GetComponent<Animator>();
        if (playerAnimator == null) Debug.Log("null");
        AC_Player = transform.root.GetComponentInChildren<AC_Player>();
        playerMovement = transform.root.GetComponentInChildren<PlayerMovement>();
    }

    public abstract void UpdateBehaviour(PlayerBehaviourManager manager);


}
