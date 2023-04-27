using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossMonsterMovement : Boss_Attk
{

    public int MoveDir = 1;

    protected void ChangeDirection()  // 이동 방향을 정할 함수
    {
        MoveDir = Random.Range(-1, 2);
        Invoke("ChangeDirection", 5);
    }

    protected IEnumerator Roaming()
    {
        while (true)
        {
            if (MoveDir == 0)
            {
                myAnim.SetBool("isMoving", false);
                yield return null; continue;
            }
            myAnim.SetBool("isMoving",true);
            SetForward(new Vector2(MoveDir, 0));
            myRigid.velocity = new Vector2(MoveDir, myRigid.velocity.y);
            yield return null;
        }
    }
    // 타겟 추적
    protected Coroutine coTrace = null;

    protected void OnTrace(Transform target)
    {
        coTrace ??= StartCoroutine(TargetTracing(target));
    }

    IEnumerator TargetTracing(Transform target)
    {
        float dist, delta;    // 방향, 거리, 프레임당 속도?
        Vector2 dir;
        while (myTarget != null)
        {
            if (!myAnim.GetBool("isAttacking"))
            {
                playTime += Time.deltaTime;
                myAnim.SetBool("isMoving", false);
                dir = target.position - transform.position;
                dir.y = 0;
                dist = dir.magnitude - AttackRange;
                dir.Normalize();
                delta = MoveSpeed * Time.deltaTime;
                SetForward(dir);
                if (dist > 0.0f)
                {
                    myAnim.SetBool("isMoving", true);
                    transform.Translate(dir * delta, Space.World);
                }
                else
                {
                    if (!myAnim.GetBool("isAttacking"))
                    {
                        if (playTime > AttackDelay)
                        {
                            int n = Random.Range(0, 3);
                            playTime = 0.0f;
                            switch(n)
                            {
                                case 0:
                                    myAnim.SetTrigger("Attack");
                                    break;
                                case 1:
                                    myAnim.SetTrigger("Swing");
                                    break;
                                case 2:
                                    myAnim.SetTrigger("Earthquake");
                                    break;

                            }
                           
                          
                           
                        }
                    }
                }
            }
            yield return null;
        }
    }
  






    // 방향 지정
    protected void SetForward(Vector2 dir)
    {
        if (dir.x > 0)
        {
            myRenderer.flipX = false;
        }
        else
        {
            myRenderer.flipX = true;
        }
    }

    // 공중 체크
    protected void AirCheck()
    {
        Debug.DrawRay(myLeftRayPos.position, Vector2.down, Color.red);
        Debug.DrawRay(myRightRayPos.position, Vector2.down, Color.red);
        RaycastHit2D leftRay = Physics2D.Raycast(myLeftRayPos.position, Vector2.down, 1f, groundMask);
        RaycastHit2D rightRay = Physics2D.Raycast(myRightRayPos.position, Vector2.down, 1f, groundMask);
        if (leftRay.collider == null && rightRay.collider == null)
        {
            myAnim.SetBool("isAir", true);
        }
        else myAnim.SetBool("isAir", false);
    }

    // 절벽 체크
    protected void CliffCheck()
    {
        Vector2 frontVec = new Vector2(transform.position.x + (MoveDir * 0.5f), transform.position.y);
        Debug.DrawRay(frontVec, Vector2.down, Color.yellow);
        RaycastHit2D cliffRay = Physics2D.Raycast(frontVec, Vector2.down, 1f, groundMask);
        if (cliffRay.collider == null)
        {
            // 공중에서의 방향 전환은 막아둠
            if (!myAnim.GetBool("isAir"))
            {
                MoveDir *= -1;
            }
        }
    }
}
