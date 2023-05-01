using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EarthDragon : PetMoveMent
{
    // 어스 드래곤 스킬 1 오브젝트
    public GameObject EarthDragonSkill1;

    // 어스 드래곤 스킬 2 오브젝트
    public GameObject EarthDragonSkill2;

    // 첫 생성 상태
    State DragonState = State.Creat;

    void Start()
    {
        // 생성되고 첫 상태 노말
        ChangeState(State.Normal);
    }

    // 어스 드래곤 상태 변경 함수.
    void ChangeState(State s)
    {
        if (DragonState == s) return;
        DragonState = s;
        switch (DragonState)
        {
            // 노말 상태일때는 플레이어만 따라다니게끔
            case State.Normal:
                StopAllCoroutines();
                StartCoroutine(DragonMoving());
                break;
            // 배틀 상태 공격.
            case State.Battle:
                StopAllCoroutines();
                StartCoroutine(Attacking(TarGet));
                break;
            default:
                Debug.Log("없는 상태 입니다.");
                break;
        }
    }

    // 어스 드래곤 상태 기능 유지 함수.
    void StateProcess()
    {
        switch (DragonState)
        {
            case State.Normal:
                break;
            case State.Battle:
                break;
            default:
                Debug.Log("없는 상태 입니다.");
                break;
        }
    }

    void Update()
    {
        StateProcess();

        // 어스 드래곤 3번 스킬 
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
        }

        // 어스 드래곤 4번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
        }
    }
}

