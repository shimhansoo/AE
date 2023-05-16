using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarkDragon : PetMoveMent
{
    // ��ũ �巡�� ��ų 1 ������Ʈ
    public GameObject DarkDragonSkill1;

    // ��ũ �巡�� ��ų 2 ������Ʈ
    public GameObject DarkDragonSkill2;

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

        // ��ũ �巡�� 3�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha3) && Skill1CoolTime <= 0.0f && TarGet != null)
        {
            Skill1CoolTime = 10.0f;
            GameObject DarkDragonThrowSkill = Instantiate(DarkDragonSkill1, transform.position, Quaternion.identity);
            DarkDragonThrowSkill.GetComponent<DragonThrowSkill>().TarGet = TarGet;
            StartCoroutine(Skill1CoolTimeCheck());
        }

        // ��ũ �巡�� 4�� ��ų ���� �� �� ����.
        rayHitCowPos = Physics2D.Raycast(transform.position, new Vector2(0,-1), 5, GroundMask);
        
        // ��ũ �巡�� 4�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha4) && Skill2CoolTime <= 0.0f)
        {
            Skill2CoolTime = 5.0f;
            CowRot = PetRenderer.flipX ? 180.0f : 0.0f;
            if(rayHitCowPos)Instantiate(DarkDragonSkill2, rayHitCowPos.point + new Vector2(0, 0.5f), Quaternion.Euler(0,CowRot,0));
            StartCoroutine(Skill2CoolTimeCheck());
        }
    }
}

