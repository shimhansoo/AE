using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MonsterMovement : MonsterProperty
{
    int throwCnt = 0;
    bool BackMove = false;
    float backMoveTime = 0f;
    // Normal ���¿����� �̵�
    int moveDir = 0;
    protected Vector2 frontVec = Vector2.zero; // ���� ����

    protected void ChangeDirection()  // �̵� ������ ���� �Լ�
    {
        moveDir = Random.Range(-1, 2);
        Invoke("ChangeDirection", 5);
    }

    protected IEnumerator Roaming()
    {
        while (true)
        {
            if (moveDir == 0)
            {
                myAnim.SetBool("isMoving", false);
                yield return null; continue;
            }
            myAnim.SetBool("isMoving", true);
            SetForward(new Vector2(moveDir, 0));
            myRigid.velocity = new Vector2(moveDir, myRigid.velocity.y);
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
        float dist, delta;    // ����, �Ÿ�
        Vector2 dir;
        while (myTarget != null)
        {
            if (!myAnim.GetBool("isAttacking"))
            {
                playTime += Time.deltaTime;
                myAnim.SetBool("isMoving", false);
                dir = target.position - transform.position;
                dir.y = 0;
                dist = dir.magnitude - autoAttackRange;
                dir.Normalize();
                delta = moveSpeed * Time.deltaTime;
                SetForward(dir);
                if (dist > 0.0f)
                {
                    if (throwCnt != 0 && playTime > attackDelay && dist > (autoAttackRange * 0.5f)) // ������
                    {
                        playTime = 0f;
                        throwCnt = 0;
                        myAnim.SetTrigger("Throw");
                        continue;
                    }
                    myAnim.SetBool("isMoving", true);
                    if (BackMove)
                    {
                        backMoveTime -= Time.deltaTime;
                        myRenderer.flipX = !myRenderer.flipX;
                        transform.Translate(-dir * delta, Space.World);
                        if (backMoveTime < 0f)
                        {
                            BackMove = false;
                            backMoveTime = -1f;
                        }
                    }
                    else transform.Translate(dir * delta, Space.World);
                }
                else
                {
                    if (!myAnim.GetBool("isAttacking"))
                    {
                        if (playTime > attackDelay)
                        {
                            playTime = 0f;
                            throwCnt = 1;
                            myAnim.SetTrigger("Attack");
                        }
                    }
                }
            }
            yield return null;
        }
    }

    // ���� ����, frontVec.x ����
    protected void SetForward(Vector2 dir)
    {
        if (dir.x > 0)
        {
            myRenderer.flipX = false;
            frontVec.x = transform.position.x + myCollider.bounds.extents.x;    // �ݶ��̴��� ��輱��ŭ
        }
        else
        {
            myRenderer.flipX = true;
            frontVec.x = transform.position.x - myCollider.bounds.extents.x;
        }
    }

    // ���� üũ
    protected void AirCheck()
    {
        Debug.DrawRay(myLeftRayPos.position, Vector2.down, Color.red);
        Debug.DrawRay(myRightRayPos.position, Vector2.down, Color.red);
        leftRay = Physics2D.Raycast(myLeftRayPos.position, Vector2.down, 1f, groundMask);
        rightRay = Physics2D.Raycast(myRightRayPos.position, Vector2.down, 1f, groundMask);
        if (leftRay.collider == null && rightRay.collider == null)
        {
            myAnim.SetBool("isAir", true);
        }
        else myAnim.SetBool("isAir", false);
    }

    // ���� üũ
    protected void CliffCheck()
    {
        frontVec.y = transform.position.y;
        Debug.DrawRay(frontVec, Vector2.down, Color.yellow);
        RaycastHit2D cliffRay = Physics2D.Raycast(frontVec, Vector2.down, 2f, groundMask);
        if (cliffRay.collider == null)
        {
            if (!myAnim.GetBool("isAir"))   // ���߿� ���� ���� ��
            {
                moveDir *= -1;
                BackMove = (myState == Monster.State.Battle); // �� ��
                backMoveTime = BackMove ? 1 : -1;
            }
        }
    }
}
