using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove; //행동지표를 결정할 변수
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 5); //5초를 딜레이 시간으로 두어서 5초마다 동작이 바뀜
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(-1, rigid.velocity.y); //왼쪽으로만 가기때문에 -1, 한방향으로만  알아서 움직이게

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y); //몬스터가 앞을 체크해야한다
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //시작,방향,색깔
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            Turn();
        }
    }
    void Think() //행동지표를 바꿔줄 함수 생각 -> 랜덤클래스 활용
    {
        nextMove = Random.Range(-1, 2); //-1:왼쪽, 0:멈추기, 1:오른쪽
        
        anim.SetInteger("WalkSpeed", nextMove);
        if(nextMove !=0) 
        {
            spriteRenderer.flipX = (nextMove == 1); //nextMove가 1이면 방향 바꾸기
        }
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
    void Turn()
    {
        nextMove = nextMove * (-1);
        spriteRenderer.flipX = (nextMove == 1);

        CancelInvoke();
        Invoke("Think", 2);
    }

}
