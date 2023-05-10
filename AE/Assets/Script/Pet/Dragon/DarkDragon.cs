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


    // 배틀 시스템 스크립트를 참조하기위한 변수.
    public BattleSystem testClass;

    public LayerMask Test;

    // 현재 타겟
    public Transform NowTarget;

    // 첫 생성 상태
    State DragonState = State.Creat;

    void Start()
    {
        // 생성되고 첫 상태 노말
        ChangeState(State.Normal);
        testClass = player.parent.GetComponent<BattleSystem>();
    }


    // 다크 드래곤 상태 변경 함수.
    void ChangeState(State s)
    {
        if (DragonState == s) return;
        DragonState = s;
        switch (DragonState)
        {
            // 노말 상태일때는 플레이어만 따라다니게끔
            case State.Normal:
                if (coAttacking != null) StopCoroutine(coAttacking);
                StartCoroutine(DragonMoving());
                break;
            // 배틀 상태 공격.
            case State.Battle:
                if (coDragonMoving != null) StopCoroutine(coDragonMoving);
                StartCoroutine(Attacking(TarGet));
                break;
            default:
                Debug.Log("없는 상태 입니다.");
                break;
        }
    }

    // 다크 드래곤 상태 유지 기능 함수.
    void StateProcess()
    {
        switch (DragonState)
        {
            case State.Normal:
                if (testClass.DragonTarget != null) TarGet = testClass.DragonTarget.transform;
                if (TarGet != null) ChangeState(State.Battle);
                break;
            case State.Battle:
                if (TarGet == null || NowTarget != TarGet) ChangeState(State.Normal);
                else TarGet = testClass.DragonTarget.transform;
                break;
            default:
                Debug.Log("없는 상태 입니다.");
                break;
        }
    }
    RaycastHit2D rayHitCowPos;
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        StateProcess();
        rayHitCowPos = Physics2D.Raycast(transform.position, new Vector2(0,-1), 5, Test);
        
        Debug.DrawRay(transform.position, new Vector2(0, -2.0f), Color.red);
        // 다크 드래곤 3번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(DarkDragonSkill1, transform.position, Quaternion.identity);
        }
        
        // 다크 드래곤 4번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(rayHitCowPos.point);
            if(rayHitCowPos)Instantiate(DarkDragonSkill2, rayHitCowPos.point + new Vector2(0, 0.5f), Quaternion.identity);
        }
    }

}

