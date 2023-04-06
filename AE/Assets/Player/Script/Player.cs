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
        //이동
        Vector2 dir = Vector2.zero;//초기값 설정
        dir.x = Input.GetAxisRaw("Horizontal");
        if (!Mathf.Approximately(dir.x, 0.0f))//왼쪽 이동
        {
                myAnim.SetBool("isMoving", true);
            if(dir.x < 0.0f)
                myRenderer.flipX = true;//좌우 반전
            else
                myRenderer.flipX = false;//좌우 반전
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
        transform.Translate(dir * playerMoveSpeed * Time.deltaTime);


        //점프
        dir.y = Input.GetAxisRaw("Vertical");
        if(!Mathf.Approximately(dir.y, 0))
        {
            myAnim.SetTrigger("Jump");
        }
        transform.Translate(dir * playerJump *  Time.deltaTime);
        
        //공격
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetTrigger("Attack");
        }
        /*예외처리
        1. 점프 공격 되게 하기
        2. 점프 후 이동하면 땅에서 점프 모션
        3. 무한 점프
        4. dir 값 동시 처리해서 무브나 점프 스피드 올리면 같이 올라감
        5. 애니스테이트에서 점프 처리할지 말지?, PlyaerStateMachine 2개 처리 이상있는지?
        6. 
         */
    }
}
