using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMan : BattleSystem
{
    //스킬 관련
    protected float playerSkillMoveSpeed_1 = 0f;
    protected float playerSkillDamage_1 = 0f;
    float spearmanSkillCoolTime1 = 7.0f;
    float spearmanSkillCoolTime2 = 10.0f;
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        playerCurHp = playerMaxHp;
        StartCoroutine(AirChecking());
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
            spearmanSkillCoolTime1 += Time.deltaTime;
            spearmanSkillCoolTime2 += Time.deltaTime;
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
            
            //스킬 1
            if (spearmanSkillCoolTime1 >= 7.0f)//7초 이후
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    spearmanSkillCoolTime1 = 0f;
                    StartCoroutine(Berserk());
                }
            }
            //스킬 2
            if (spearmanSkillCoolTime2 >= 10.0f)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    spearmanSkillCoolTime2 = 0f;
                    GameObject temp = Instantiate(Resources.Load("Player/SpearManSkill2"), new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity)as GameObject;
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
    IEnumerator Berserk()
    {
        playerSkillMoveSpeed_1 = playerMoveSpeed;
        playerSkillDamage_1 = playerDamege;

        playerMoveSpeed *= 1.5f;
        playerDamege *= 2.0f;
        attackSpeed = 5.0f;

        GameObject temp = Instantiate(Resources.Load("Player/SpearManSkill1"), new Vector2(transform.position.x, transform.position.y+0.2f), Quaternion.identity) as GameObject;
        temp.transform.SetParent(this.transform);
        yield return new WaitForSeconds(5.0f);

        Destroy(temp);
        playerMoveSpeed = playerSkillMoveSpeed_1;
        playerDamege = playerSkillDamage_1;
        attackSpeed = 1.0f;
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null) return;
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y - 0.5f), 0.3f);
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
    /*private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
    }*/
}
