using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarkDragon : PetMoveMent
{
    // ��ũ �巡�� ��ų 1 ������Ʈ
    public GameObject DarkDragonSkullSkill;

    // ��ũ �巡�� ��ų 2 ������Ʈ
    public GameObject DarkDragonSkillLaser;

    void Start()
    {
        // �����ǰ� ù ���� �븻
        ChangeState(State.Normal);
        TarGetRepScript = player.parent.GetComponent<BattleSystem>();
    }

    void Update()
    {        
        // �巡�� ���±�� ���� , ��ȯ �Լ�.
        StateProcess();

        // ��ũ �巡�� Q ��ų
        if (Input.GetKeyDown(KeyCode.Q) && SkillQCoolTime <= 0.0f && TarGet != null)
        {
            SkillQCoolTime = 5.0f;
            GameObject DarkDragonThrowSkill = Instantiate(DarkDragonSkullSkill, transform.position, Quaternion.identity);
            DarkDragonThrowSkill.GetComponent<DragonThrowSkill>().TarGet = TarGet;
            StartCoroutine(SkillQCoolTimeCheck());
        }

        // ��ũ �巡�� W ��ų ���� �� �� ����.
        rayHitCowPos = Physics2D.Raycast(transform.position, new Vector2(0,-1), 5, GroundMask);
        
        // ��ũ �巡�� W ��ų
        if (Input.GetKeyDown(KeyCode.W) && SkillWCoolTime <= 0.0f)
        {
            SkillWCoolTime = 10.0f;
            CowRot = PetRenderer.flipX ? 180.0f : 0.0f;
            if(rayHitCowPos)Instantiate(DarkDragonSkillLaser, rayHitCowPos.point + new Vector2(0, 0.5f), Quaternion.Euler(0,CowRot,0));
            StartCoroutine(SkillWCoolTimeCheck());
        }
    }
}

