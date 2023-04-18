using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadState : StateMachineBehaviour
{
    Transform enemyTransform;
    Enemy enemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<Enemy>();
        enemyTransform = animator.GetComponent<Transform>();
    }

     
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(enemy.atkDelay <=0)
        animator.SetTrigger("Attack");

        if (Vector2.Distance(enemy.player.position, enemyTransform.position) > 1f)
            animator.SetBool("IsFollow", true);
        enemy.DirectionEnemy(enemy.player.position.x, enemyTransform.position.x);
    }

  
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

   
}
