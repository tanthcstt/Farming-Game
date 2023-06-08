using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    
    public static AnimationManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

   
    public bool IsTransitTo(Animator animator, string src, string des)
    {
        AnimatorStateInfo current = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo next = animator.GetNextAnimatorStateInfo(0);
       
        if (current.IsName(src) && next.IsName(des) && src!= des)
        {          
            return true;
        }
        return false;
    }
    public bool IsPlaying (Animator animator, string animationName)
    {
        AnimatorStateInfo current = animator.GetCurrentAnimatorStateInfo(0);
        return current.IsName(animationName) && current.normalizedTime > 0; 
    }
}
