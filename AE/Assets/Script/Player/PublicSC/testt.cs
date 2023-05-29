using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testt : PlayerMovement
{
    private void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
    }
    private void FixedUpdate()
    {
        //if (isDashing) return;
        OnMove1();
        Scalesetting();
    }
    // Update is called once per frame
    void Update()
    {
        OnJump();
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //StartCoroutine(coJump());
        }
        GroundCh();
    }
   /* private bool canDash = true;
    private bool isDashing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    float tmpGravity; 
    IEnumerator coJump()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = myRigid.gravityScale;
        myRigid.gravityScale = 0f;
        myRigid.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        //tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        //tr.emitting = false;
        myRigid.gravityScale = originalGravity;
        myRigid.velocity = new Vector2(0, 0);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }*/
    protected void OnMove1()//¿Ãµø
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
            dir.y = myRigid.velocity.y;
            myRigid.velocity = new Vector2(dir.x * 5f, dir.y);
        }
    }
    RaycastHit2D HitUpLeft = new RaycastHit2D();
    RaycastHit2D HitUpRight = new RaycastHit2D();
    RaycastHit2D HitDownLeft = new RaycastHit2D();
    RaycastHit2D HitDownRight = new RaycastHit2D();

    void GroundCh()
    {
        HitUpLeft = Physics2D.Raycast(myRigid.position + new Vector2(-0.3f, 0), Vector2.up, 0.6f, groundMask);

        HitUpRight = Physics2D.Raycast(myRigid.position + new Vector2(0.3f, 0), Vector2.up, 0.6f, groundMask);
        HitDownRight = Physics2D.Raycast(myRigid.position + new Vector2(0.3f, 0), Vector2.up, -0.6f, groundMask);
        HitDownLeft = Physics2D.Raycast(myRigid.position + new Vector2(-0.3f, 0), Vector2.up, -0.6f, groundMask);

        if (HitDownRight.collider != null || HitDownLeft.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(test());
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine(testUp());
        }

        Debug.DrawRay(myRigid.position + new Vector2(-0.3f, 0), new Vector2(0, 0.6f), Color.red);
        Debug.DrawRay(myRigid.position + new Vector2(-0.3f, 0), new Vector2(0, -0.6f), Color.red);
        Debug.DrawRay(myRigid.position + new Vector2(0.3f, 0), new Vector2(0, 0.6f), Color.red);
        Debug.DrawRay(myRigid.position + new Vector2(0.3f, 0), new Vector2(0, -0.6f), Color.red);
    }
    IEnumerator test()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        canMove = false;
        yield return new WaitForSeconds(0.8f);
        canMove = true;
        Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);
    }
    IEnumerator testUp()
    {
        //Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        //Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);
    }
}
