
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : StateMachineBehaviour
{
      int Count = Random.Range(1, 6);
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("Skill");
        
        
        
        GameObject obj1 = Instantiate(Resources.Load("BossMonsters/Fire") as GameObject);
        obj1.transform.position = new Vector2(animator.transform.position.x + (Random.Range(-5f, 5f)), animator.transform.position.y + 5f);
        

    }

    
    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

   
}
