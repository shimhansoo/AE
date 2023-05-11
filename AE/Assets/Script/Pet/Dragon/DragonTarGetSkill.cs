using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonTarGetSkill : PetMoveMent
{
    // ���� �� 2�ʸ��� ������
    private void Start()
    {
        StartCoroutine(OnDamage(2.0f));
    }

    // ���࿡ Ÿ���� �װų� ������ٸ� ���ӿ�����Ʈ ���� �ƴҰ�� Ÿ���� ����ٴϴ� TarGetSkill�Լ� �ߵ�.
    private void Update()
    {
        if (TarGet == null) Destroy(gameObject);
        else TarGetSkill();        
    }

    // ������ �ð����� Ÿ���� ����ٴϴ� Ÿ�� ��ų �Լ�
    void TarGetSkill()
    {        
        transform.position = TarGet.position + new Vector3(0,DragonTargetSkillPosY,0);
        DurationCountTime += Time.deltaTime;
        if (TarGetSkillDuration < DurationCountTime)
        {
            // ���ӽð� ��������ŭ DurationCountTime �����ߴٸ� ����.
            Destroy(gameObject);
        }        
    }

    // DamageDelay�Ķ���� �� ���� �������� ������.
    IEnumerator OnDamage(float DamageDelay)
    {
        while(true)
        {            
            yield return new WaitForSeconds(DamageDelay);
            SkillDamage(DragonSkillDamage2);
        }
    }
}
