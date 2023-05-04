using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEarth : StateMachineBehaviour
{
  
    
    public float EarthDamage = 10.0f;
    public float attackRange = 10.0f;
    


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("Earthquake");
      
        GameObject objLeft = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        objLeft.transform.position = new Vector3(animator.transform.position.x - 2.0f, animator.transform.position.y, animator.transform.position.z);
        GameObject objRight = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        objRight.transform.position = new Vector3(animator.transform.position.x + 2.0f, animator.transform.position.y, animator.transform.position.z);



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false);
        animator.ResetTrigger("Earthquake");

        GameObject objLeft = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        objLeft.transform.position = new Vector3(animator.transform.position.x - 2.0f, animator.transform.position.y, animator.transform.position.z);
        GameObject objRight = Instantiate(Resources.Load("BossMonsters/Earth")) as GameObject;
        objRight.transform.position = new Vector3(animator.transform.position.x + 2.0f, animator.transform.position.y, animator.transform.position.z);

    }



}




