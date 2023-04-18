using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterProperty
{
    public void SlimeAttack()   // �������� ����ü ����
    {
        GameObject obj = Instantiate(Resources.Load("Monster/Mon_Slime_Spit"),GetComponentInParent<Transform>()) as GameObject;
        obj.transform.position = transform.position;
    }
    public void ShamanTotem()
    {
        GameObject obj = Instantiate(Resources.Load("Monster/Mon_ShamanTotem")) as GameObject;
        obj.transform.position = new Vector2(transform.position.x, transform.position.y);
    }
}
