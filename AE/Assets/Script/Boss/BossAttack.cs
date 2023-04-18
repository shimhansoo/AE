using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonsterMovement
{
    public void bossAttack()
    {
        GameObject obj = Instantiate(Resources.Load("BossSpit"), GetComponentInParent<Transform>()) as GameObject;
        obj.transform.position = transform.position;
    }
}
