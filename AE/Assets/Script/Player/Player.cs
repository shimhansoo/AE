using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty, GameManager.IBattle
{
    Vector2 dir = Vector2.zero;//이동
    Vector2 frontVec = Vector2.zero;
    Rigidbody2D rigidbody = new Rigidbody2D();//리지드바듸
    RaycastHit2D rayHitLeft = new RaycastHit2D();
    RaycastHit2D rayHitRight = new RaycastHit2D();
    public LayerMask GroundMask;
    bool isJump = false;
    int playerLayer, groundLayer;
    float collTime = 0.0f;
    int count = 0;
    public GameObject DebuffIcon = null;    // 토템 디버프 아이콘
    public GameObject dashEffect;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        StartCoroutine(AirChecking());
        playerCurHp = playerMaxHp;

    }
    private void FixedUpdate()
    {
        OnMove();
    }
    void Update()
    {
        // 플레이어 속도 계산, 현재속도 = 기본속도 + 증감치
        playerCurrentMoveSpeed = playerMoveSpeed + additionalSpeed;

        Dash();

        if (Input.GetKeyDown(KeyCode.X))
        {
            myAnim.SetTrigger("Attack");
        }


        isJump = rayHitLeft || rayHitRight ? isJump = false : isJump = true;//레이를 쐈을 때 감지되는 무언가가 있다면 false or true, true는 공중상태를 얘기함

        if (!Mathf.Approximately(dir.x, 0.0f))
        {
            transform.localScale = dir.x < 0.0f ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        }

        if (!isJump)
            OnJump();
        else
            collisionCheck();
    }


    //대쉬
    void Dash()
    {
        collTime += Time.deltaTime;
        if (collTime >= 2.0f)
        {
            if (count < 2) count++;
            collTime = 0.0f;
        }
        if (count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                count--;
                rigidbody.AddForce(frontVec * 10.0f, ForceMode2D.Impulse);
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                Instantiate(dashEffect, transform.position, Quaternion.identity);
            }
        }
    }
    void collisionCheck()//점프 bool값 처리와 점프할 때 콜라이더 체크 후 충돌 On/Off
    {
        if (rigidbody.velocity.y > 0.0f)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);
        }
    }


    //점프
    void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
    }



    public void OnTakeDamage(float damage)
    {
        playerCurHp -= damage;
        myAnim.SetTrigger("Damage");
        if (playerCurHp <= 0)
        {
            myAnim.SetTrigger("Death");
            //Destroy(gameObject);
        }
    }

    public Transform attackPoint;
    public float attackRange = 0.7f;
    public LayerMask enemyLayers;

    //어택
    public void OnAttack()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);//반지름 오버랩 생성
        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(playerDamege);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

    //이동
    void OnMove()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        if (dir.x == 1) frontVec.x = 1;
        else if (dir.x == -1) frontVec.x = -1;

        if (!Mathf.Approximately(dir.x, 0.0f))//이동
        {
            myAnim.SetBool("isMoving", true);
            //transform.localScale = dir.x < 0.0f ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
        transform.Translate(dir * playerCurrentMoveSpeed * Time.deltaTime);

    }

    //레이
    IEnumerator AirChecking()
    {
        while (true)
        {
            rayHitRight = Physics2D.Raycast(rigidbody.position + new Vector2(-0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 1.5f, GroundMask);
            rayHitLeft = Physics2D.Raycast(rigidbody.position + new Vector2(0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 1.5f, GroundMask);
            yield return new WaitForFixedUpdate();
        }
    }



}
