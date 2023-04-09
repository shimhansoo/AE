using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
{
    Vector2 dir = Vector2.zero;//�̵�
    Vector2 jumpDir = Vector2.zero;//����
    Rigidbody2D rigidbody;//������ٵ�
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        OnMove();
        OnAttack();
        //onAirCheck();
        OnJump();
        
    }
 
    
    //����
    void OnJump()
    {
            /*jumpDir.y = Input.GetAxisRaw("Vertical");
            transform.Translate(jumpDir * playerJump * Time.deltaTime);*/
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);

    }
    void onAirCheck()
    {
        Vector2 test = new Vector2(0, -0.5f);
        Debug.DrawRay(rigidbody.position, Vector3.down, Color.red);
        RaycastHit2D rayHit = Physics2D.Raycast(rigidbody.position, test, 1);
        if(rayHit.collider != null)
        {
                myAnim.SetBool("isJumping", false);
        }
    
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
