using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonThrowSkill : PetMoveMent
{
    private void Update()
    {
        if (TarGet == null) Destroy(gameObject);
        else ThrowSkill();
    }

    void ThrowSkill()
    {
        Vector2 dir = TarGet.position - transform.position;
        PetRenderer.flipX = dir.x > 0.0f ? true : false;        
        transform.Translate(dir * ThrowSkillSpeed * Time.deltaTime, Space.World);
        if (Mathf.Abs(dir.y) <= 1.0f && Mathf.Abs(dir.x)<= 1.0f)
        {
            // ����Ʈ �����ڰ� �ִٸ� ���� Ÿ�ٿ� ��ų ������Ʈ�� ���� �� ��ų Ÿ�� ����Ʈ�� ����.
            if (SkillEffect != null)
            {
               GameObject TargetSkillTarget = Instantiate(SkillEffect, TarGet.position + new Vector3(0,0.5f,0), Quaternion.identity);
                TargetSkillTarget.GetComponent<DragonTarGetSkill>().enabled = true;
                TargetSkillTarget.GetComponent<DragonTarGetSkill>().TarGet = TarGet;
            }
            // ��ô ��ų ������Ʈ ����.
            SkillDamage(DragonSkillDamage1);
            Destroy(gameObject);
        }
    }
}
