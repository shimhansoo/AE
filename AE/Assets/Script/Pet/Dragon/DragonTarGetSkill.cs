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
    // ������ �ð����� Ÿ���� ����ٴϴ� Ÿ�� ��ų.
    void TartGetSkill()
    {
        
        transform.position = TarGet.position + new Vector3(0,0.5f,0);
        DurationCountTime += Time.deltaTime;
        if (TarGetSkillDuration < DurationCountTime)
        {
            // ���ӽð� ��������ŭ DurationCountTime �����ߴٸ� ����.
            Destroy(gameObject);
        }        
    }
    // DamageDelay�ʸ��� �������� ������.
    IEnumerator OnDamage(float DamageDelay)
    {
        while(true)
        {
            SkillDamage(20.0f);
            yield return new WaitForSeconds(DamageDelay);
        }
    }
}
