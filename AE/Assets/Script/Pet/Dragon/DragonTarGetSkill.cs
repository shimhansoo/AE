using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTarGetSkill : PetProperty
{
    // 공격 타겟 값.
    public Transform Target;    
    
    private void Start()
    {
        transform.position = Target.position;
    }
    private void Awake()
    {
        GameObject TargetPos = GameObject.Find("OrcWarrior");
        Target = TargetPos.transform;
    }
    private void Update()
    {
        TartGetSkill();
    }
    void TartGetSkill()
    {
        transform.position = Target.position;
        DurationCountTime += Time.deltaTime;
        if (TarGetSkillDuration < DurationCountTime)
        {
            // 지속시간 설정값만큼 DurationCountTime 증가했다면 삭제.
            Destroy(gameObject);
        }
    }
}
