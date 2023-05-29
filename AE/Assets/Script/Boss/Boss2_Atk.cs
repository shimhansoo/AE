using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_Atk : Boss2Movement
{
    // Start is called before the first frame update
    public void BossAttack()
    {
        Collider2D[] colList = Physics2D.OverlapCircleAll(new Vector3(frontVec.x, transform.position.y, transform.position.z), attackRange * 1.0f, targetMask);
        foreach (Collider2D col in colList)
        {
            col.GetComponent<GameManager.IBattle>().OnTakeDamage(attackDamage);
        }
    }
    public void BreathAttack()
    {

        Collider2D[] colList = Physics2D.OverlapCircleAll(new Vector3(frontVec.x, transform.position.y, transform.position.z), attackRange * 1.5f, targetMask);
        foreach (Collider2D col in colList)
        {
            col.GetComponent<GameManager.IBattle>().OnTakeDamage(BreathDamage);
        }
    }
    public void SmashAttack()
    {

        Collider2D[] colList = Physics2D.OverlapCircleAll(new Vector3(frontVec.x, transform.position.y, transform.position.z), attackRange * 3.0f, targetMask); ;
        foreach (Collider2D col in colList)
        {
            col.GetComponent<GameManager.IBattle>().OnTakeDamage(SmashDamage);
        }
    }
    public void fireslimeAttack()
    {
        GameObject obj = Instantiate(Resources.Load("BossMonsters/fireslime_bolt"), transform) as GameObject;
        obj.transform.position = transform.position;
    }



}
