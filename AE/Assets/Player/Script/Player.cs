using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�̵�
        Vector2 dir = Vector2.zero;//�ʱⰪ ����
        dir.x = Input.GetAxisRaw("Horizontal");
        if (!Mathf.Approximately(dir.x, 0.0f))//���� �̵�
        {
                myAnim.SetBool("isMoving", true);
            if(dir.x < 0.0f)
                myRenderer.flipX = true;//�¿� ����
            else
                myRenderer.flipX = false;//�¿� ����
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
        transform.Translate(dir * playerMoveSpeed * Time.deltaTime);


        //����
        dir.y = Input.GetAxisRaw("Vertical");
        if(!Mathf.Approximately(dir.y, 0))
        {
            myAnim.SetTrigger("Jump");
        }
        transform.Translate(dir * playerJump *  Time.deltaTime);
        
        //����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetTrigger("Attack");
        }
        /*����ó��
        1. ���� ���� �ǰ� �ϱ�
        2. ���� �� �̵��ϸ� ������ ���� ���
        3. ���� ����
        4. dir �� ���� ó���ؼ� ���곪 ���� ���ǵ� �ø��� ���� �ö�
        5. �ִϽ�����Ʈ���� ���� ó������ ����?, PlyaerStateMachine 2�� ó�� �̻��ִ���?
        6. 
         */
    }
}
