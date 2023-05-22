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
            transform.localScale = frontVec.x < 0.0f ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);
    }
    
    protected void OnMove()//이동
    {
        dir.x = Input.GetAxisRaw("Horizontal");
        if (dir.x == 1) frontVec.x = 1;
        else if (dir.x == -1) frontVec.x = -1;

        if (canMove)
        {
            if (!Mathf.Approximately(dir.x, 0.0f))
            {
                myAnim.SetBool("isMoving", true);
            }
            else
            {
                myAnim.SetBool("isMoving", false);
            }
            transform.Translate(dir * playerCurrentMoveSpeed * Time.fixedDeltaTime);
        }
    }
    protected void Dash()//대쉬
    {
        coolTime += Time.deltaTime;
        if (coolTime >= 2.0f)
        {
            if (dashCount < 2)
            {
                dashCount++;
                coolTime = 0.0f;
            }
        }
        if (dashCount > 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                dashCount--;
                myRigid.AddForce(frontVec * 10.0f, ForceMode2D.Impulse);
                canMove = false;
                Instantiate(Resources.Load("Player/PlayerDash"), new Vector2(transform.position.x, transform.position.y + 0.4f), Quaternion.identity);
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
        {
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        }
    }
    
    protected IEnumerator AirChecking()//바닥이 Ground, Wall 확인
    {
        while (true)
        {
            //rayHitDownRight = Physics2D.Raycast(myRigid.position + new Vector2(-0.6f, 1) * 0.5f, Vector2.down, GetComponent<Rigidbody2D>().velocity.magnitude * Time.fixedDeltaTime + 1.5f, groundMask);
            //rayHitDownLeft = Physics2D.Raycast(myRigid.position + new Vector2(0.6f, 1) * 0.5f, Vector2.down, GetComponent<Rigidbody2D>().velocity.magnitude * Time.fixedDeltaTime + 1.5f, groundMask);
            groundCheck = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 0.5f), 0.3f, groundMask);

            if (groundCheck != null)
            {
                canMove = true;
            }
            yield return new WaitForFixedUpdate();
        }
    }

}