using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
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
    void Start()
    {
        _playerMoveSpeed = playerMoveSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        StartCoroutine(AirChecking());
    }
    void Update()
    {
        Dash();
        OnAttack();
        OnMove();
        isJump = rayHitLeft || rayHitRight ? isJump = false : isJump = true;//레이를 쐈을 때 감지되는 무언가가 있다면 false or true, true는 공중상태를 얘기함

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
            //Debug.Log(count);

        }
        if (count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                count--;
                rigidbody.AddForce(frontVec * 10.0f, ForceMode2D.Impulse);
                //Debug.Log(count);
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
    //어택
    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
            myAnim.SetTrigger("Attack");
    }

    //이동
    void OnMove()
    {
        dir.x = Input.GetAxisRaw("Horizontal");

        if (dir.x == 1) frontVec.x = 1;
        else if (dir.x == -1) frontVec.x = -1;

        if (!Mathf.Approximately(dir.x, 0.0f))//왼쪽 이동
        {
            myAnim.SetBool("isMoving", true);
            myRenderer.flipX = dir.x < 0.0 ? true : false;
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
        transform.Translate(dir * playerMoveSpeed * Time.deltaTime);
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
