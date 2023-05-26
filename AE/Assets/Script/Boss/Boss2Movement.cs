using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Movement : Boss2Property
{
    protected bool SkillCool = false;
    bool Backmove = false;
    float BackmoveTime = 0f;
    public int MoveDir = 1;
   protected Vector2 frontVec = Vector2.zero;

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
            myAnim.SetBool("isMoving", true);
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
        float dist, delta;
        Vector2 dir;
        while (myTarget != null)
        {
            if (!myAnim.GetBool("isAttacking"))
            {
                playTime += Time.deltaTime;
                myAnim.SetBool("isMoving", false);
                dir = target.position - transform.position;
                dir.y = 0;
                dist = dir.magnitude - attackRange;
                dir.Normalize();
                delta = MoveSpeed * Time.deltaTime;
                SetForward(dir);

                if (dist > 0.0f)
                {
                    myAnim.SetBool("isMoving", true);
                    if (Backmove)
                    {
                        BackmoveTime -= Time.deltaTime;
                        myRenderer.flipX = !myRenderer.flipX;
                        transform.Translate(-dir * delta, Space.World);
                        if (BackmoveTime < 0f)
                        {
                            Backmove = false;
                            BackmoveTime = -1f;
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
                            int n = Random.Range(0, 4);
                            playTime = 0.0f;
                            switch (n)
                            {
                                case 0:
                                    myAnim.SetTrigger("Attack");
                                   
                                    break;
                             
                                case 1:
                                    myAnim.SetTrigger("Smash");
                                    
                                    break;
                                case 2:
                                    myAnim.SetTrigger("BreathSkill");
                                    
                                    break;

                                case 3:
                                    if (!this.SkillCool)
                                    {
                                        SkillCooltime += Time.deltaTime;
                                        if (SkillCooltime >= 20.0f)
                                        {

                                            myAnim.SetTrigger("Skill");
                                            this.SkillCool = true;



                                        }
                                    }
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
            myRenderer.flipX = true;
            frontVec.x = transform.position.x + myCollider.bounds.extents.x;
        }
        else
        {
            myRenderer.flipX = false;
            frontVec.x = transform.position.x - myCollider.bounds.extents.x;
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
        frontVec.y = transform.position.y;
        Debug.DrawRay(frontVec, Vector2.down, Color.yellow);
        RaycastHit2D cliffRay = Physics2D.Raycast(frontVec, Vector2.down, 2f, groundMask);
        if (cliffRay.collider == null)
        {
            if (!myAnim.GetBool("isAir"))   // 공중에 있지 않을 때
            {
                MoveDir *= -1;
                Backmove = (myState == Boss2.State.Battle); 
                BackmoveTime = Backmove ? 1 : -1;
            }
        }
    }
}
