using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterProperty
{
    Vector2 dir = Vector2.zero;//�̵�
    Vector2 frontVec = Vector2.zero;
    Rigidbody2D rigidbody = new Rigidbody2D();//������ٵ�
    RaycastHit2D rayHitLeft = new RaycastHit2D();
    RaycastHit2D rayHitRight = new RaycastHit2D();
    public LayerMask GroundMask;
    bool isJump = false;
    int playerLayer, groundLayer;
    float collTime = 0.0f;
    int count = 0;
    public GameObject DebuffIcon = null;    // ���� ����� ������
    void Start()
    {
        _playerMoveSpeed = playerMoveSpeed;
        rigidbody = GetComponent<Rigidbody2D>();
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        StartCoroutine(AirChecking());
    }
    void Update()
    {
        Dash();
        OnAttack();
        OnMove();
        isJump = rayHitLeft || rayHitRight ? isJump = false : isJump = true;//���̸� ���� �� �����Ǵ� ���𰡰� �ִٸ� false or true, true�� ���߻��¸� �����

        if (!isJump)
            OnJump();
        else
            collisionCheck();
    }
    //�뽬
    void Dash()
    {
        collTime += Time.deltaTime;
        if (collTime >= 2.0f)
        {
            if (count < 2) count++;
            collTime = 0.0f;
            //Debug.Log(count);

        }
        if (count > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                count--;
                rigidbody.AddForce(frontVec * 10.0f, ForceMode2D.Impulse);
                //Debug.Log(count);
            }
        }

    }
    void collisionCheck()//���� bool�� ó���� ������ �� �ݶ��̴� üũ �� �浹 On/Off
    {
        if (rigidbody.velocity.y > 0.0f)
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
            rigidbody.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
    }
    //����
    void OnAttack()
    {
        if (Input.GetKeyDown(KeyCode.X))
            myAnim.SetTrigger("Attack");
    }

    //�̵�
    void OnMove()
    {
        dir.x = Input.GetAxisRaw("Horizontal");

        if (dir.x == 1) frontVec.x = 1;
        else if (dir.x == -1) frontVec.x = -1;

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
    IEnumerator AirChecking()
    {
        while (true)
        {
            rayHitRight = Physics2D.Raycast(rigidbody.position + new Vector2(-0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 1.5f, GroundMask);
            rayHitLeft = Physics2D.Raycast(rigidbody.position + new Vector2(0.6f, 1) * 0.5f, Vector2.down, rigidbody.velocity.magnitude * Time.fixedDeltaTime + 1.5f, GroundMask);
            yield return new WaitForFixedUpdate();
        }
    }



}
