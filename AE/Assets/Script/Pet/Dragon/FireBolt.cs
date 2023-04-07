using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBolt : PetProperty
{
    public float testTime = 0.0f;
    public float AttackSpeed = 2.0f;
    public float CoolTime = 5.0f;
    public Transform DragonPos = null;
    public Transform PlayerPos = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        testTime += Time.deltaTime;
        CoolTime += Time.deltaTime;
        

        if(PetAnim.GetBool("isAttacking"))
        {
            if (DragonPos.position.x < PlayerPos.position.x)
            {
                PetRenderer.flipX = false;
                transform.Translate(Vector2.right * AttackSpeed * Time.deltaTime);
            }
            else
            {
                PetRenderer.flipX = true;
                transform.Translate(-Vector2.right * AttackSpeed * Time.deltaTime);
            }
        }
        if (testTime >= 2.0f)
        {
            PetAnim.SetBool("isAttacking", false);
        }
        if(testTime >= 2.5f)
        {
            transform.position = DragonPos.position;
            testTime = 0.0f;
        }
        if (CoolTime > 10.0f)
        {
            PetAnim.SetBool("isAttacking", true);
            CoolTime = 0.0f;
        }
    }
}
