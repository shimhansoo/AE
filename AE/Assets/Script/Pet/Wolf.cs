using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : PetProperty
{
    public LayerMask GroundMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = player.position - transform.position;
        float delta = PetSpeed * Time.deltaTime;
        dir.Normalize();
        if (dir.x < 0.0f)
        {
            PetRenderer.flipX = true;
        }
        else
        {
            PetRenderer.flipX = false;
        }
        if (Mathf.Abs(transform.position.x - player.position.x) > 1.0f)
        {
            PetAnim.SetBool("isMoving", true);
            transform.Translate(dir * delta);
            Vector2 test = (Vector2)transform.position + Vector2.up; // 이거 1은 너무 높다.
            RaycastHit2D hit = Physics2D.Raycast(test, transform.right * -1.0f, 0.5f, GroundMask);
            RaycastHit2D hit2 = Physics2D.Raycast(test, transform.right * 1.0f, 0.5f, GroundMask);
            Debug.DrawRay(test, transform.right * 1.0f);
            Debug.DrawRay(test, transform.right * -1.0f);
            if (hit || hit2)
            {
                transform.Translate(Vector2.up * PetJump *Time.deltaTime,Space.World);
            }
        }
        else
        {
            PetAnim.SetBool("isMoving", false);
        }
        if (Mathf.Abs(transform.position.x - player.position.x) > 5.0f)
        {
            PetAnim.SetTrigger("Telleport");
            transform.position = new Vector3(player.position.x, player.position.y + 1.0f, 0);
        }
    }
}
