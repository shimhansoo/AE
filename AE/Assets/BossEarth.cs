using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEarth : StateMachineBehaviour, GameManager.IBattle
{
    public float maxHealth = 100.0f;
    private float currentHealth;
    public float EarthDamage = 10.0f;
    public float attackRange = 5.0f;
    private void DealDamage(Animator Earthquake)
    {
        Collider[] colliders = Physics.OverlapSphere(Earthquake.transform.position, attackRange);
        foreach (Collider enemyCollider in colliders)
        {
            if (enemyCollider.gameObject.CompareTag("Player"))
            {
                GameManager.IBattle player = enemyCollider.gameObject.GetComponent<GameManager.IBattle>();
                if (player != null)
                {
                    player.OnTakeDamage(EarthDamage);
                }
            }
        }
    }


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("Earthquake");

        DealDamage(animator);


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

        DealDamage(animator);


    }

    public void OnTakeDamage(float dmg)
    {
        throw new NotImplementedException();
    }
}


