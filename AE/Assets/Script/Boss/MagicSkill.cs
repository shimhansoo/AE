using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : StateMachineBehaviour
{
    private bool SkillCool = false; // 추가 변수 설정

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", true);


        if (!SkillCool) // 첫 번째 실행인 경우에만 실행
        {
            GameObject obj1 = Instantiate(Resources.Load("BossMonsters/Fireslime") as GameObject);
            obj1.transform.position = new Vector2(animator.transform.position.x + (Random.Range(-3f, 3f)), animator.transform.position.y);
            GameObject obj2 = Instantiate(Resources.Load("BossMonsters/Fireslime") as GameObject);
            obj2.transform.position = new Vector2(animator.transform.position.x + (Random.Range(-3f, 3f)), animator.transform.position.y);

            SkillCool = true; // 첫 번째 실행 이후에는 실행되지 않도록 설정
        }
        
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false);
       

       
    }
}
