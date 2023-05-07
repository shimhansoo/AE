using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonThrowSkill : PetProperty
{
    // ��ô ��ų ����Ʈ�� �ִٸ� ����.
    public GameObject Effect;
    private void Update()
    {
        ThrowSkill();
    }

    void ThrowSkill()
    {
        Vector2 dir = TarGet.position - transform.position;
        PetRenderer.flipX = dir.x > 0.0f ? true : false;        
        transform.Translate(dir * ThrowSkillSpeed * Time.deltaTime , Space.World);
        if (Mathf.Abs(dir.y) <= 1.0f && Mathf.Abs(dir.x)<= 1.0f)
        {
            // ����Ʈ �����ڰ� �ִٸ� ���� Ÿ�ٿ� ��ų ������Ʈ�� ���� �� ��ų Ÿ�� ����Ʈ�� ����.
            if (Effect != null)
            {
               GameObject TargetSkillTarget = Instantiate(Effect, TarGet.position + new Vector3(0,0.5f,0), Quaternion.identity);
                TargetSkillTarget.GetComponent<DragonTarGetSkill>().enabled = true;
                TargetSkillTarget.GetComponent<DragonTarGetSkill>().TarGet = TarGet;
            }
            // ��ô ��ų ������Ʈ ����.
            Destroy(gameObject);
        }
    }
}
