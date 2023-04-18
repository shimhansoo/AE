using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
{
    Vector2 dir = Vector2.zero;//�̵�
    Rigidbody2D rigidbody;//������ٵ�
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
        isJump = rayHitLeft || rayHitRight ? isJump = false : isJump = true;//���̸� ���� �� �����Ǵ� ���𰡰� �ִٸ� false or true, true�� ���߻��¸� �����

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

    void collisionCheck()//���� bool�� ó���� ������ �� �ݶ��̴� üũ �� �浹 On/Off
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


    //����
    void OnJump()
    {
        
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);
    }
    //����
    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            myAnim.SetTrigger("Attack");
        }
    }
   

    //����
    IEnumerator AirChecking()
    {
        while (true)
        {
            rayHitRight = Physics2D.Raycast(rigidbody.position + new Vector2(-0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 0.5f , GroundMask);
            rayHitLeft = Physics2D.Raycast(rigidbody.position + new Vector2(0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 0.5f, GroundMask);
            yield return new WaitForFixedUpdate();
        }
    }

    //�̵�
    IEnumerator PlayerMoving()
    {
        while (true)
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
            yield return null;
        }
    }

}
