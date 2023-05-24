using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarkDragon : PetMoveMent
{
    // 다크 드래곤 스킬 1 오브젝트
    public GameObject DarkDragonSkullSkill;

    // 다크 드래곤 스킬 2 오브젝트
    public GameObject DarkDragonSkillLaser;

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

        // 다크 드래곤 Q 스킬
        if (Input.GetKeyDown(KeyCode.Q) && SkillQCoolTime <= 0.0f && TarGet != null)
        {
            SkillQCoolTime = 5.0f;
            GameObject DarkDragonThrowSkill = Instantiate(DarkDragonSkullSkill, transform.position, Quaternion.identity);
            DarkDragonThrowSkill.GetComponent<DragonThrowSkill>().TarGet = TarGet;
            StartCoroutine(SkillQCoolTimeCheck());
        }

        // 다크 드래곤 W 스킬 레이 쏜 후 저장.
        rayHitCowPos = Physics2D.Raycast(transform.position, new Vector2(0,-1), 5, GroundMask);
        
        // 다크 드래곤 W 스킬
        if (Input.GetKeyDown(KeyCode.W) && SkillWCoolTime <= 0.0f)
        {
            SkillWCoolTime = 10.0f;
            CowRot = PetRenderer.flipX ? 180.0f : 0.0f;
            if(rayHitCowPos)Instantiate(DarkDragonSkillLaser, rayHitCowPos.point + new Vector2(0, 0.5f), Quaternion.Euler(0,CowRot,0));
            StartCoroutine(SkillWCoolTimeCheck());
        }
    }
}

