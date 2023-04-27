using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss_Attk : BossProperty
{
    // Start is called before the first frame update
    public void MinoAttack()
    {
        GameObject obj = Instantiate(Resources.Load("BossMonster/enemy"), GetComponentInParent<Transform>()) as GameObject;
        obj.transform.position = transform.position;
       
    }
}
