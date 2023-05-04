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
            // ���ӽð� ��������ŭ DurationCountTime �����ߴٸ� ����.
            Destroy(gameObject);
        }
    }
}
