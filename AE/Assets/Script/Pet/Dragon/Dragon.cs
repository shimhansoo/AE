using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : PetProperty
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // transform.position = new Vector3(player.position.x, player.position.y + 1.0f, 0);
    {
        Vector2 dir = player.position - transform.position;
        float dist = dir.magnitude;
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
            PetAnim.SetBool("isFlying", true);
            transform.Translate(dir * Time.deltaTime * PetSpeed);
        }
        else
        {
            PetAnim.SetBool("isFlying", false);
        }
        
    }
}
