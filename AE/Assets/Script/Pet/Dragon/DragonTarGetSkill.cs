using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTarGetSkill : PetMoveMent
{
    // 생성 후 2초마다 데미지
    private void Start()
    {
        StartCoroutine(OnDamage(2.0f));
    }

    // 만약에 타겟이 죽거나 사라졌다면 게임오브젝트 삭제 아닐경우 타겟을 따라다니느 TarGetSkill함수 발동.
    private void Update()
    {
        if (TarGet == null) Destroy(gameObject);
        else TarGetSkill();        
    }

    // 정해진 시간동안 타겟을 따라다니는 타겟 스킬 함수
    void TarGetSkill()
    {        
        transform.position = TarGet.position + new Vector3(0,DragonTargetSkillPosY,0);
        DurationCountTime += Time.deltaTime;
        if (TarGetSkillDuration < DurationCountTime)
        {
            // 지속시간 설정값만큼 DurationCountTime 증가했다면 삭제.
            Destroy(gameObject);
        }        
    }

    // DamageDelay파라매터 초 마다 데미지를 입힌다.
    IEnumerator OnDamage(float DamageDelay)
    {
        while(true)
        {            
            yield return new WaitForSeconds(DamageDelay);
            SkillDamage(DragonSkillDamageW);
        }
    }
}
