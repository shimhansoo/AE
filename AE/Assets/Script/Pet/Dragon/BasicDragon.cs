using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicDragon : PetMoveMent
{
    // 첫 생성 상태
    State DragonState = State.Creat;

    void Start()
    {
        // 생성되고 첫 상태 노말
        ChangeState(State.Normal);
    }

    private void Awake()
    {
        // 플레이어 바인딩 대신에 임시로.
        GameObject PlayerPos = GameObject.Find("DragonTarget");
        player = PlayerPos.transform;
    }

    // 베이직 드래곤 상태 변경 함수.
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

    // 베이직 드래곤 상태 유지 기능 함수.
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
    }
}

