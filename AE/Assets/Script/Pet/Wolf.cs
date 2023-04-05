using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : PetProperty
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
            PetAnim.SetBool("isMoving", true);
            transform.Translate(dir * Time.deltaTime * PetSpeed);
        }
        else
        {
            PetAnim.SetBool("isMoving", false);
        }
        if (Mathf.Abs(transform.position.x - player.position.x) > 5.0f)
        {
            PetAnim.SetTrigger("PetTp");
            transform.position = new Vector3(player.position.x, player.position.y + 1.0f, 0);
        }
    }
}
