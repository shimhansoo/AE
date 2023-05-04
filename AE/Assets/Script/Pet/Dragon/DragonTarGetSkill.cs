using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTarGetSkill : FireDragon
{    
    private void Start()
    {
        transform.position = TarGet.position;
    }
    private void Awake()
    {
        TarGet = player.parent.GetComponent<BattleSystem>().DragonTarget.transform;
    }
    private void Update()
    {
        TartGetSkill();
    }
    void TartGetSkill()
    {
        transform.position = TarGet.position;
        DurationCountTime += Time.deltaTime;
        if (TarGetSkillDuration < DurationCountTime)
        {
            // 지속시간 설정값만큼 DurationCountTime 증가했다면 삭제.
            Destroy(gameObject);
        }
    }
}
