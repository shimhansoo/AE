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
    }
    
    private void FixedUpdate()
    {
        if (isLive)
        {
        OnMove();
        }
    }

    void Update()
    {
        if (isLive)
        {
            playerCurrentMoveSpeed = playerMoveSpeed + additionalSpeed;

            //대쉬
            Dash();

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
            isJump = rayHitLeft || rayHitRight ? isJump = false : isJump = true;
            jumpCool += Time.deltaTime;
            if (!isJump && jumpCool >= 0.5f)
            {
                OnJump();
            }
            else
                collisionCheck();
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
