using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTarGetSkill : PetMoveMent
{
    float count = 2.0f;
    private void Start()
    {
        StartCoroutine(SkillDamageCount());
    }
    private void Update()
    {
        TartGetSkill();
    }
    void TartGetSkill()
    {
        transform.position = TarGet.position + new Vector3(0,0.5f,0);
        DurationCountTime += Time.deltaTime;
        if (TarGetSkillDuration < DurationCountTime)
        {
            // 지속시간 설정값만큼 DurationCountTime 증가했다면 삭제.
            Destroy(gameObject);
        }        
    }
    IEnumerator SkillDamageCount()
    {
        while(true)
        {
            count += Time.deltaTime;
            if(count >2.0f)
            {
                SkillDamage(20.0f);
                count = 0;
            }
            yield return null;
        }
    }
}
