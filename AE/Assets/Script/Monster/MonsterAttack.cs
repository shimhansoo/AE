using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonsterMovement
{
    public void SlimeAttack()
    {
        GameObject obj = Instantiate(Resources.Load("Slime_Spit"),GetComponentInParent<Transform>()) as GameObject;
        obj.transform.position = transform.Find("SpitPoint").position;
    }
}
