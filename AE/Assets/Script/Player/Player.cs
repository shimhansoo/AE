using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
{
    Vector2 dir = Vector2.zero;//이동
    Rigidbody2D rigidbody;//리지드바듸
    RaycastHit2D rayHit = new RaycastHit2D();
    public LayerMask GroundMask;
    bool isJump = false;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        AirCheck();
    }

    void Update()
    {
        OnMove();
        OnAttack();

        isJump = rayHit.collider != null ? isJump = false : isJump = true;
        if (!isJump) OnJump();
    }
 
    
    //점프
    void OnJump()
    {
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);
    }


    void AirCheck()
    {
        Debug.DrawRay(rigidbody.position + Vector2.up * 0.5f, new Vector3(0, -0.7f, 0), Color.red);
        rayHit = Physics2D.Raycast(rigidbody.position + Vector2.up * 0.5f, Vector2.down, 0.7f, GroundMask);
    }

    //이동
    void OnMove()
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
    }
    //어택
    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            myAnim.SetTrigger("Attack");
        }
    }
   
}

/*예외처리
        1. 점프 공격 되게 하기
        2. 점프 후 이동하면 땅에서 점프 모션
        3. 무한 점프
        4. dir 값 동시 처리해서 무브나 점프 스피드 올리면 같이 올라감
        5. 애니스테이트에서 점프 처리할지 말지?, PlyaerStateMachine 2개 처리 이상있는지?
        6. 
         */
