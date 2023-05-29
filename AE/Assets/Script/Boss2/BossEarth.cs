using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEarth : StateMachineBehaviour
{
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    // }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false);
        animator.ResetTrigger("Earthquake");
        GameObject objLeft1 = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        GameObject objLeft2 = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        GameObject objLeft3 = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        objLeft1.transform.position = new Vector2(animator.transform.position.x - 3.0f, animator.transform.position.y + 5.0f);
        objLeft2.transform.position = new Vector2(animator.transform.position.x - 8.0f, animator.transform.position.y + 5.0f);
        objLeft3.transform.position = new Vector2(animator.transform.position.x - 13.0f, animator.transform.position.y + 5.0f);

        GameObject objRight1 = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        GameObject objRight2 = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        GameObject objRight3 = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        objRight1.transform.position = new Vector2(animator.transform.position.x + 3.0f, animator.transform.position.y + 5.0f);
        objRight2.transform.position = new Vector2(animator.transform.position.x + 8.0f, animator.transform.position.y + 5.0f);
        objRight3.transform.position = new Vector2(animator.transform.position.x + 13.0f, animator.transform.position.y + 5.0f);

        Destroy(objLeft1, 1.0f);
        Destroy(objLeft2, 1.0f);
        Destroy(objLeft3, 1.0f);
        Destroy(objRight1, 1.0f);
        Destroy(objRight2, 1.0f);
        Destroy(objRight3, 1.0f);
    }
}



