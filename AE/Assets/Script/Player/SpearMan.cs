using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMan : BattleSystem
{
    // 드래곤 임시.
    public GameObject BasicDragon;
    public GameObject FireDragon;
    public GameObject EarthDragon;
    public GameObject DarkDragon;

    public bool berserk = false;
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        playerCurHp = playerMaxHp;
        StartCoroutine(AirChecking());
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    void Update()
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

        //스킬 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Berserk());
        }

        //무한 점프 제어
        isJump = rayHitLeft || rayHitRight ? isJump = false : isJump = true;
        if (!isJump)
            OnJump();
        else
            collisionCheck();

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

    IEnumerator Berserk()
    {
        if (berserk) yield break;
        berserk = true;
        playerSkillMoveSpeed_1 = playerMoveSpeed;
        playerSkillDamage_1 = playerDamege;

        playerMoveSpeed *= 1.5f;
        playerDamege *= 2.0f;
        attackSpeed = 10.0f;

        GameObject temp = Instantiate(skillEffect1, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        temp.transform.SetParent(this.transform);
        yield return new WaitForSeconds(5.0f);

        Destroy(temp);
        berserk = false;
        playerMoveSpeed = playerSkillMoveSpeed_1;
        playerDamege = playerSkillDamage_1;
        attackSpeed = 1.0f;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}

