using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove; //�ൿ��ǥ�� ������ ����
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Invoke("Think", 5); //5�ʸ� ������ �ð����� �ξ 5�ʸ��� ������ �ٲ�
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(-1, rigid.velocity.y); //�������θ� ���⶧���� -1, �ѹ������θ�  �˾Ƽ� �����̰�

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y); //���Ͱ� ���� üũ�ؾ��Ѵ�
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0)); //����,����,����
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            Turn();
        }
    }
    void Think() //�ൿ��ǥ�� �ٲ��� �Լ� ���� -> ����Ŭ���� Ȱ��
    {
        nextMove = Random.Range(-1, 2); //-1:����, 0:���߱�, 1:������
        
        anim.SetInteger("WalkSpeed", nextMove);
        if(nextMove !=0) 
        {
            spriteRenderer.flipX = (nextMove == 1); //nextMove�� 1�̸� ���� �ٲٱ�
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
