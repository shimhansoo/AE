using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss_Attk : BossMonsterMovement
{
    
    // Start is called before the first frame update
    public void BossAttack()
    {
       
        Collider2D[] colList = Physics2D.OverlapCircleAll(new Vector3(frontVec.x, transform.position.y, transform.position.z), attackRange * 0.8f, targetMask);
        foreach (Collider2D col in colList)
        {
            col.GetComponent<GameManager.IBattle>().OnTakeDamage(attackDamge);
        }
    }
    public void SwingAttack()
    {

        Collider2D[] colList = Physics2D.OverlapCircleAll(new Vector3(frontVec.x, transform.position.y, transform.position.z), attackRange * 1.0f, targetMask);
        foreach (Collider2D col in colList)
        {
            col.GetComponent<GameManager.IBattle>().OnTakeDamage(SwingDamage);
        }
    }


    public void MinoEarth()   
    {
        GameObject obj = Instantiate(Resources.Load("BossMonsters/Earth"), transform) as GameObject;
        obj.transform.position = transform.position;
    }

}
