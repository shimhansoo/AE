using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Atk : Boss2Movement
{
    // Start is called before the first frame update
    public void BossAttack()
    {
        Collider2D[] colList = Physics2D.OverlapCircleAll(new Vector3(frontVec.x, transform.position.y, transform.position.z), attackRange * 0.6f, targetMask);
        foreach (Collider2D col in colList)
        {
            col.GetComponent<GameManager.IBattle>().OnTakeDamage(attackDamage);
        }
    }
    public void BossSkill()
    {
        GameObject obj = Instantiate(Resources.Load("BossMonsters/Fire"), transform) as GameObject;
        obj.transform.position = new Vector2(transform.position.x+(Random.Range(-5f, 5f)), transform.position.y + 5f);
       

    }


}