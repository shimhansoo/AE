using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTarGetSkill : PetMoveMent
{
    private void Start()
    {
        StartCoroutine(OnDamage(2.0f));
    }
    private void Update()
    {
        if (TarGet == null) Destroy(gameObject);
        else TartGetSkill();        
    }
    // 정해진 시간동안 타겟을 따라다니는 타겟 스킬.
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
    // DamageDelay초마다 데미지를 입힌다.
    IEnumerator OnDamage(float DamageDelay)
    {
        while(true)
        {
            SkillDamage(20.0f);
            yield return new WaitForSeconds(DamageDelay);
        }
    }
}
