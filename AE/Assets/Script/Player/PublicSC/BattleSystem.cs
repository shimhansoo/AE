using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : PlayerMovement, GameManager.IBattle
{
    public GameObject DragonTarget = null;
    public bool isLive
    {
        get
        {
            if(!Mathf.Approximately(playerCurHp,0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public void OnTakeDamage(float damage)
    {
        playerCurHp -= damage;
        myAnim.SetTrigger("OnDamageColor");
        if (Mathf.Approximately(playerCurHp, 0))
        {
            myAnim.SetTrigger("Death");
            Destroy(this.myRigid);
            transform.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
    
    public void OnAttack()
    {
        playerDamege = Random.Range(15, 25);
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(playerDamege);
            DragonTarget = enemy.gameObject;
        }
    }

}
