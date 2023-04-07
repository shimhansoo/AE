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
        if(coTrace != null) StopCoroutine(coTrace);
        myAnim.SetBool("isMoving", false);
        myTarget = null;
        coTrace = null;
    }
    // Target Tracing
    Coroutine coTrace = null;
    protected void onTrace(Collider2D col)
    {
        if(coTrace == null) coTrace = StartCoroutine(TargetTracing(col));
    }
    public float JumpPower = 3.0f;
    IEnumerator TargetTracing(Collider2D col)
    {
        GetTarget(col); // 타겟 확인
        float dir, dist, delta;    // 방향, 거리, 프레임당 속도?
        while (myTarget != null)
        {
            myAnim.SetBool("isAir", true);
            Debug.DrawRay(transform.position, Vector2.down, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundMask);
            if (hit.collider != null) 
                if(hit.distance < 0.5f) myAnim.SetBool("isAir", false);
            if (!myAnim.GetBool("isAir")) myRigid.AddForce(Vector2.up * JumpPower);
            myAnim.SetBool("isMoving", true);
            dir = col.transform.position.x - transform.position.x;
            dist = (col.transform.position - transform.position).magnitude - AttackRange;
            delta = MoveSpeed * Time.deltaTime;
            if (delta > dist) delta = dist;
            transform.Translate(new Vector2(dir, 0) * delta);

            yield return null;
        }
    }

    protected void AirCheck()
    {
        //Debug.DrawRay(transform.position, Vector2.down, Color.red);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, groundMask);
        //if (hit.collider != null)
        //{
        //    if (hit.distance < 0.3f)
        //        myAnim.SetBool("isAir", false);
        //}
    }
}
