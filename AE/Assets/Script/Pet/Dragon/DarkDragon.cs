using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DarkDragon : PetMoveMent
{
    // 다크 드래곤 스킬 1 오브젝트
    public GameObject DarkDragonSkill1;

    // 다크 드래곤 스킬 2 오브젝트
    public GameObject DarkDragonSkill2;

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

        // 다크 드래곤 3번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(DarkDragonSkill1, transform.position, Quaternion.identity);
        }

        // 다크 드래곤 4번 스킬 레이 쏜 후 저장.
        rayHitCowPos = Physics2D.Raycast(transform.position, new Vector2(0,-1), 5, GroundMask);
        
        // 다크 드래곤 4번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CowRot = PetRenderer.flipX ? 180.0f : 0.0f;
            if(rayHitCowPos)Instantiate(DarkDragonSkill2, rayHitCowPos.point + new Vector2(0, 0.5f), Quaternion.Euler(0,CowRot,0));
        }
    }
}

