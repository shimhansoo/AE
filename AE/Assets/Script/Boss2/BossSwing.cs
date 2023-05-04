using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSwing : StateMachineBehaviour
{
    public float SwingDamage = 2.0f;
    public float SwingRange = 5.0f;

   

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("Swing");
       
    }

   
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   // {
        
   // }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false);
        animator.ResetTrigger("Swing");

       
    }

  
}
