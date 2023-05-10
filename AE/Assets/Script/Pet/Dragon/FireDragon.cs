using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : PetMoveMent
{
    // 파이어 드래곤 스킬 1 오브젝트
    public GameObject FireDragonSprit1;
    public GameObject FireDragonSprit2;
    public GameObject FireDragonSprit3;
    public GameObject FireDragonSprit4;

    // 파이어 드래곤 스킬 2 오브젝트
    public GameObject FireDragonSkill2;

    void Start()
    {
        // 생성되고 첫 상태 노말
        ChangeState(State.Normal);
        TarGetRepScript = player.parent.GetComponent<BattleSystem>();
    }

    void Update()
    {
        // 드래곤 상태기계 유지 , 변환 함수.
        StateProcess();

        // 파이어 드래곤 3번 스킬
        if(Input.GetKeyDown(KeyCode.Alpha3) && issprit && Skill1CoolTime <= 0.0f)
        {
            issprit = false;
            Skill1CoolTime = 10.0f;
            GameObject FireSpritSkill1 = Instantiate(FireDragonSprit1, transform.position + new Vector3(0.5f,1.5f,0), Quaternion.identity, transform);
            GameObject FireSpritSkill2 = Instantiate(FireDragonSprit2, transform.position + new Vector3(-0.5f, 1.5f, 0), Quaternion.identity, transform);
            GameObject FireSpritSkill3 = Instantiate(FireDragonSprit3, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity, transform);
            GameObject FireSpritSkill4 = Instantiate(FireDragonSprit4, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity, transform);
            FireSpritSkill4.GetComponent<FireSpritSkill>().FireSpritReset.AddListener(FireSpiritResetFunc);
            DragonFireSpritSkillTargetSetting(FireSpritSkill1);
            DragonFireSpritSkillTargetSetting(FireSpritSkill2);
            DragonFireSpritSkillTargetSetting(FireSpritSkill3);
            DragonFireSpritSkillTargetSetting(FireSpritSkill4);
            StartCoroutine(Skill1CoolTimeCheck());
        }

        // 파이어 드래곤 4번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha4) && Skill2CoolTime <= 0.0f && TarGet != null)
        {
            Skill2CoolTime = 5.0f;
            GameObject FireThrowSkill = Instantiate(FireDragonSkill2, transform.position, Quaternion.identity);
            DragonThrowSkillTargetSetting(FireThrowSkill);
            StartCoroutine(Skill2CoolTimeCheck());
        }
    }

    // 파이어 드래곤 3번 스킬중복사용 제한 bool 값 true변환 함수.
    public void FireSpiritResetFunc()
    {
        issprit = true;
    }

    // 파이어 드래곤 3번스킬 타겟설정.
    void DragonFireSpritSkillTargetSetting(GameObject Target)
    {
        Target.GetComponent<FireSpritSkill>().TarGet = TarGet;
    }

    // 파이어 드래곤 4번스킬 타겟설정.
    void DragonThrowSkillTargetSetting(GameObject Target)
    {
        Target.GetComponent<DragonThrowSkill>().TarGet = TarGet;
    }
}

