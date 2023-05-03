using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterProperty
{
    protected void collisionCheck()//Ground 충돌 무시
    {
        if (myRigid.velocity.y > 0.0f)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);
        }
    }

    protected void Scalesetting()//좌우반전
    {
        if (!Mathf.Approximately(dir.x, 0.0f))
        {
            transform.localScale = dir.x < 0.0f ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
        }
    }

    protected void OnMove()//이동
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        if (dir.x == 1) frontVec.x = 1;
        else if (dir.x == -1) frontVec.x = -1;

        if (!Mathf.Approximately(dir.x, 0.0f))
        {
            myAnim.SetBool("isMoving", true);
        }
        else
        {
            myAnim.SetBool("isMoving", false);
        }
        transform.Translate(dir * playerCurrentMoveSpeed * Time.deltaTime);
    }

    protected void Dash()//대쉬
    {
        collTime += Time.deltaTime;
        if (collTime >= 2.0f)
        {
            if (dashCount < 2)
            {
                dashCount++;
                collTime = 0.0f;
            }
        }
        if (dashCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dashCount--;
                myRigid.AddForce(frontVec * 7.0f, ForceMode2D.Impulse);
                Instantiate(dashEffect, new Vector2(transform.position.x, transform.position.y + 0.4f), Quaternion.identity);
            }
        }
    }

    protected void OnJump()//↑ 점프, ↓ 점프
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            myRigid.AddForce(Vector2.up * playerJumpPower, ForceMode2D.Impulse);
            jumpCool = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
    }

    protected IEnumerator AirChecking()//바닥이 Ground, Wall 확인
    {
        while (true)
        {
            rayHitRight = Physics2D.Raycast(myRigid.position + new Vector2(-0.6f, 1) * 0.5f, Vector2.down, GetComponent<Rigidbody2D>().velocity.magnitude * Time.fixedDeltaTime + 1.5f, groundMask);
            rayHitLeft = Physics2D.Raycast(myRigid.position + new Vector2(0.6f, 1) * 0.5f, Vector2.down, GetComponent<Rigidbody2D>().velocity.magnitude * Time.fixedDeltaTime + 1.5f, groundMask);
            yield return new WaitForFixedUpdate();
        }
    }

}
