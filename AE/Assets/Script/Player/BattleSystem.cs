using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : PlayerMovement, GameManager.IBattle
{
    public void OnTakeDamage(float damage)
    {
        playerCurHp -= damage;
        myAnim.SetTrigger("Damage");
        if (playerCurHp <= 0)
        {
            myAnim.SetTrigger("Death");
            //Destroy(gameObject);
        }
    }

    public void OnAttack()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(playerDamege);
        }
    }
}
