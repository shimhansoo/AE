using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPlayer : CharacterProperty
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float MoveSpeed = 2.0f;
    public float PlayerJump = 10.0f;
    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.zero;
        dir.x = Input.GetAxisRaw("Horizontal"); // ��ǲ�Ŵ����� �ִ� �ǵ� 
        // GetAxis �� ������ �ް� ������ �޴� ���� , GetAxis�� ������ ������ -1 ~ 1 ���� ������ �׿����ϴ�.
        // �̰Ÿ� �����Ϸ��� GetAxisRaw�� ���� �˴ϴ�.

        if (!Mathf.Approximately(dir.x, 0.0f))
        {
            if (dir.x < 0.0f) // �������� �̵��ϸ�
            {
                myRenderer.flipX = true; // �¿����
            }
            else
            {
                myRenderer.flipX = false;
            }
        }       
        transform.Translate(dir * MoveSpeed * Time.deltaTime);
        dir.y = Input.GetAxisRaw("Vertical");
        transform.Translate(dir * PlayerJump * Time.deltaTime);
    }
}
