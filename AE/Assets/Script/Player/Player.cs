using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
{
    Vector2 dir = Vector2.zero;//�̵�
    Rigidbody2D rigidbody;//������ٵ�
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
 
    
    //����
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

    //�̵�
    void OnMove()
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        if (!Mathf.Approximately(dir.x, 0.0f))//���� �̵�
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
    //����
    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            myAnim.SetTrigger("Attack");
        }
    }
   
}

/*����ó��
        1. ���� ���� �ǰ� �ϱ�
        2. ���� �� �̵��ϸ� ������ ���� ���
        3. ���� ����
        4. dir �� ���� ó���ؼ� ���곪 ���� ���ǵ� �ø��� ���� �ö�
        5. �ִϽ�����Ʈ���� ���� ó������ ����?, PlyaerStateMachine 2�� ó�� �̻��ִ���?
        6. 
         */
