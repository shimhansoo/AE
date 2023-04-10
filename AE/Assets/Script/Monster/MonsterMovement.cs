using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonsterProperty
{
    // Normal ���¿����� �̵�
    public int MoveDir = 1;

    protected void ChangeDirection()  // �̵� ������ ���� �Լ�
    {
        MoveDir = Random.Range(-1, 2);
        Invoke("ChangeDirection", 5);
    }

    protected IEnumerator Roaming()
    {
        while(true)
        {
            if(MoveDir == 0)
            {
                myAnim.SetBool("isMoving", false);
                yield return null;continue;
            }
            myAnim.SetBool("isMoving", true);
            SetForward(new Vector2(MoveDir, 0));
            myRigid.velocity = new Vector2(MoveDir, myRigid.velocity.y);
            yield return null;
        }
    }
    // Ÿ�� ����
    protected Coroutine coTrace = null;

    protected void OnTrace(Transform target)
    {
        coTrace ??= StartCoroutine(TargetTracing(target));
    }

    IEnumerator TargetTracing(Transform target)
    {
        float dist, delta;    // ����, �Ÿ�, �����Ӵ� �ӵ�?
        Vector2 dir;
        while (myTarget != null)
        {
            if (!myAnim.GetBool("isAttacking"))
            {
                playTime += Time.deltaTime;
                myAnim.SetBool("isMoving", false);
                dir = target.position - transform.position;
                dir.y = 0;
                dist = (target.position - transform.position).magnitude - AttackRange;
                dir.Normalize();
                delta = MoveSpeed * Time.deltaTime;
                if (dist > 0.0f)
                {
                    SetForward(dir);
                    myAnim.SetBool("isMoving", true);
                    transform.Translate(dir * delta, Space.World);
                }
                else
                {
                    SetForward(dir);
                    if (!myAnim.GetBool("isAttacking"))
                    {
                        if (playTime > AttackDelay)
                        {
                            playTime = 0.0f;
                            myAnim.SetTrigger("Attack");
                        }
                    }
                }
            }
            yield return null;
        }
    }

    // ���� ����
    void SetForward(Vector2 dir)
    {
        if (dir.x > 0)
        {
            //myRenderer.flipX = false;
            transform.eulerAngles = new Vector2(transform.rotation.x, 0);
        }
        else
        {
            //myRenderer.flipX = true;
            transform.eulerAngles = new Vector2(transform.rotation.x, 180);
        }
    }

    // ���� üũ
    protected void AirCheck()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100f, groundMask);
        if (hit.collider != null)
        {
            if (hit.distance > 0.2f) myAnim.SetBool("isAir", true);
            else myAnim.SetBool("isAir", false);
        }
    }
}
