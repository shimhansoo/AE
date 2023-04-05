using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonsterProperty
{
    // Get Target
    protected void GetTarget(Collider2D col)
    {
        if (myTarget == null)
        {
            if( (1 << col.gameObject.layer & targetMask) != 0)
                myTarget = col.transform;
        }
    }
    // Lost Target
    protected void LostTarget(Collider2D col)
    {
        myTarget = null;
    }
    // Target Tracing
}
