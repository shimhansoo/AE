using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMan : BattleSystem
{
    //스킬 관련
    protected float playerSkillMoveSpeed_1 = 0f;
    protected float playerSkillDamage_1 = 0f;
    public GameObject SpearManskillEffect1;
    public GameObject SpearManskillEffect2;
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
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    spearmanSkillCoolTime1 = 0f;
                    StartCoroutine(Berserk());
                }
            }
            //스킬 2
            if (spearmanSkillCoolTime2 >= 10.0f)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    spearmanSkillCoolTime2 = 0f;
                    GameObject temp = Instantiate(SpearManskillEffect2, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
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
            // 드래곤 구현 확인을 위한 구문.
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Instantiate(BasicDragon, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                Instantiate(FireDragon, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                Instantiate(EarthDragon, transform.position, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                Instantiate(DarkDragon, transform.position, Quaternion.identity);
            }
        }
    }
    IEnumerator Berserk()
    {
        playerSkillMoveSpeed_1 = playerMoveSpeed;
        playerSkillDamage_1 = playerDamege;

        playerMoveSpeed *= 1.5f;
        playerDamege *= 2.0f;
        attackSpeed = 10.0f;

        GameObject temp = Instantiate(SpearManskillEffect1, new Vector2(transform.position.x, transform.position.y+0.2f), Quaternion.identity);
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
