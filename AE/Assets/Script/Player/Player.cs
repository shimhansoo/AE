using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
{
    Vector2 dir = Vector2.zero;//이동
    Rigidbody2D rigidbody;//리지드바듸
    RaycastHit2D rayHitLeft = new RaycastHit2D();
    RaycastHit2D rayHitRight = new RaycastHit2D();
    public LayerMask GroundMask;
    bool isJump = false;
    int playerLayer, groundLayer;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        StartCoroutine(PlayerMoving());
        StartCoroutine(AirChecking());
    }

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        OnAttack();
        isJump = rayHitLeft || rayHitRight ? isJump = false : isJump = true;//레이를 쐈을 때 감지되는 무언가가 있다면 false or true, true는 공중상태를 얘기함

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        }
        if (!isJump)
        {
            OnJump();
        }
        else
        {
            collisionCheck();
        }
    }

    void collisionCheck()//점프 bool값 처리와 점프할 때 콜라이더 체크 후 충돌 On/Off
    {
        if ( rigidbody.velocity.y > 0.0f)
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
        
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);
    }
    //어택
    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            myAnim.SetTrigger("Attack");
        }
    }
   

    //레이
    IEnumerator AirChecking()
    {
        while (true)
        {
            rayHitRight = Physics2D.Raycast(rigidbody.position + new Vector2(-0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 0.5f , GroundMask);
            rayHitLeft = Physics2D.Raycast(rigidbody.position + new Vector2(0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 0.5f, GroundMask);
            yield return new WaitForFixedUpdate();
        }
    }

    //이동
    IEnumerator PlayerMoving()
    {
        while (true)
        {
        dir.x = Input.GetAxisRaw("Horizontal");
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
            yield return null;
        }
    }

}
