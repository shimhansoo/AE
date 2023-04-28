using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonThrowSkill : PetProperty
{
    // ��ų Ÿ�� ��.
    public Transform Target;

    // ��ô ��ų ����Ʈ�� �ִٸ� ����.
    public GameObject Effect;
    
    private void Awake()
    {
        // �ӽ�
        GameObject TargetPos = GameObject.Find("OrcWarrior");
        Target = TargetPos.transform;
    }
    private void Update()
    {
        ThrowSkill();
    }

    void ThrowSkill()
    {
        Vector2 dir = Target.position - transform.position;
        PetRenderer.flipX = dir.x > 0.0f ? true : false;        
        transform.Translate(dir * ThrowSkillSpeed * Time.deltaTime , Space.World);
        if (Mathf.Abs(dir.y) <= 1.0f && Mathf.Abs(dir.x)<= 1.0f)
        {
            // ����Ʈ �����ڰ� �ִٸ� ���� Ÿ�ٿ� ��ų ������Ʈ�� ���� �� ��ų Ÿ�� ����Ʈ�� ����.
            if(Effect != null)
            {
            Instantiate(Effect, Target.position, Quaternion.identity);
            }
            // ��ô ��ų ������Ʈ ����.
            Destroy(gameObject);
        }
    }
}
