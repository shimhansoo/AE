using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterMovement
{
    public void AutoAttack()  // 기본 공격
    {
        Collider2D[] colList = Physics2D.OverlapCircleAll(new Vector3(frontVec.x, transform.position.y, transform.position.z), autoAttackRange * 0.6f, targetMask);
        foreach (Collider2D col in colList)
        {
            col.GetComponent<GameManager.IBattle>().OnTakeDamage(attackDamage);
        }
    }
    public void SlimeAttack()   // 슬라임 투사체 공격
    {
        GameObject obj = Instantiate(Resources.Load("Monster/Mon_Slime_Spit"), transform) as GameObject;
        obj.transform.position = transform.position;
    }
    public void OrcThrowAttack()   // 오크 도끼 던지기
    {
        GameObject obj = Instantiate(Resources.Load("Monster/Mon_OrcThrowAxe"), transform) as GameObject;
        obj.transform.position = transform.position;
    }
    public void ShamanTotem()   // 고블린 샤먼 토템 소환
    {
        GameObject obj = Instantiate(Resources.Load("Monster/Mon_ShamanTotem"), transform) as GameObject;
        obj.transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
    }
   

}
