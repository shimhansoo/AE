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
        dir.x = Input.GetAxisRaw("Horizontal"); // 인풋매니저에 있는 건데 
        // GetAxis 는 가속을 받고 감속을 받는 느낌 , GetAxis는 누르고 있으면 -1 ~ 1 까지 점점점 쌓여갑니다.
        // 이거를 방지하려면 GetAxisRaw를 쓰면 됩니다.

        if (!Mathf.Approximately(dir.x, 0.0f))
        {
            if (dir.x < 0.0f) // 왼쪽으로 이동하면
            {
                myRenderer.flipX = true; // 좌우반전
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
