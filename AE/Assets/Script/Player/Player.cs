using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BattleSystem
{
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        playerCurHp = playerMaxHp;
        StartCoroutine(AirChecking());
    }
    public float gvs = 5f;
    private void FixedUpdate()
    {
        if (isLive)
        {
        OnMove();
        }
        //myRigid.AddForce(Physics2D.gravity * (gvs - 1) * myRigid.mass);
    }

    void Update()
    {
        if (isLive)
        {
            playerCurrentMoveSpeed = playerMoveSpeed + additionalSpeed;

            //대쉬
            Dash();
            //test();
            //좌우반전
            Scalesetting();

            //기본공격 시간 제어
            attackTime += Time.deltaTime * attackSpeed;
            if (attackTime >= 0.5f)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    myAnim.SetTrigger("Attack");
                    attackTime = 0.0f;
                }
            }
            //무한 점프 제어
            //isJump = rayHitDownLeft || rayHitDownRight ? isJump = false : isJump = true;
            isJump = groundCheck ? isJump = false : isJump = true;
            jumpCool += Time.deltaTime;
            if (!isJump && jumpCool >= 0.5f)
            {
                OnJump();
            }
            else
            {
                collisionCheck();
            }
        }
    }
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravity = 40;
    public void test()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            myRigid.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        if(myRigid.velocity.y >= 0)
        {
            myRigid.gravityScale = gravityScale;
        }
        else if(myRigid.velocity.y < 0)
        {
            myRigid.gravityScale = fallingGravity;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        //Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y - 0.5f), 0.3f);
        //Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
