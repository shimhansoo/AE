using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterProperty
{
    public void SlimeAttack()   // 슬라임의 투사체 공격
    {
        GameObject obj = Instantiate(Resources.Load("Monster/Mon_Slime_Spit"), transform) as GameObject;
        obj.transform.position = transform.position;
    }
    public void ShamanTotem()
    {
        GameObject obj = Instantiate(Resources.Load("Monster/Mon_ShamanTotem"), transform) as GameObject;
        obj.transform.position = new Vector2(transform.position.x + Random.Range(-3, 4), transform.position.y + 0.04f);
    }
}
