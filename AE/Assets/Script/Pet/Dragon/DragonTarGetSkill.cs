using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTarGetSkill : PetProperty
{
    // ���� Ÿ�� ��.
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
            // ���ӽð� ��������ŭ DurationCountTime �����ߴٸ� ����.
            Destroy(gameObject);
        }
    }
}
