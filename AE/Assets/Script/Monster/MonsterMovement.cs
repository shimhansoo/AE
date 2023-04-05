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
        StopCoroutine(coTrace);
        myAnim.SetBool("isMove", false);
        myTarget = null;
        coTrace = null;
    }
    // Target Tracing
    Coroutine coTrace = null;
    protected void onTrace(Collider2D col)
    {
        if(coTrace == null) coTrace = StartCoroutine(TargetTracing(col));
    }
    IEnumerator TargetTracing(Collider2D col)
    {
        GetTarget(col); // 타겟 확인
        float dir, dist, delta;    // 방향, 거리, 프레임당 속도?
        while (myTarget != null)
        {
            myAnim.SetBool("isMove", true);
            dir = col.transform.position.x - transform.position.x;
            delta = MoveSpeed * Time.deltaTime;
            transform.Translate(new Vector2(dir, 0) * delta);

            yield return null;
        }
    }
}
