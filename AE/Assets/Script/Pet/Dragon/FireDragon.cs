using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.Events;*/

public class FireDragon : PetMoveMent
{
    public Transform NowTarget;

    // 배틀 시스템 스크립트를 참조하기위한 변수.
    public BattleSystem testClass;

    // 파이어 드래곤 스킬 1 오브젝트
    public GameObject FireDragonSprit1;
    public GameObject FireDragonSprit2;
    public GameObject FireDragonSprit3;
    public GameObject FireDragonSprit4;
    // 파이어 드래곤 스킬 1 임시 락
    public bool isspirit = true;

    // 파이어 드래곤 스킬 2 오브젝트
    public GameObject FireDragonSkill2;

    // 첫 생성 상태
    [SerializeField]State DragonState = State.Creat;

    void Start()
    {        
        // 생성되고 첫 상태 노말
        ChangeState(State.Normal);
        testClass = player.parent.GetComponent<BattleSystem>();
    }

    // 파이어 드래곤 상태 변경 함수.
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
                NowTarget = TarGet;
                break;
            default:
                Debug.Log("없는 상태 입니다.");
                break;
        }
    }

    // 파이어 드래곤 상태 기능 유지 함수.
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
    // Update is called once per frame
    void Update()
    {
        // 배틀시스템 스크립트를 참조함
        
        

        StateProcess();

        // 파이어 드래곤 3번 스킬
        if(Input.GetKeyDown(KeyCode.Alpha3) && isspirit)
        {
            isspirit = false;
            Instantiate(FireDragonSprit1, transform.position, Quaternion.identity);
            Instantiate(FireDragonSprit2, transform.position, Quaternion.identity);
            Instantiate(FireDragonSprit3, transform.position, Quaternion.identity);
            Instantiate(FireDragonSprit4, transform.position, Quaternion.identity);
        }

        // 파이어 드래곤 4번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject SkillTarget = Instantiate(FireDragonSkill2, transform.position, Quaternion.identity);
            SkillTarget.GetComponent<DragonThrowSkill>().enabled=true;
            SkillTarget.GetComponent<DragonThrowSkill>().TarGet = TarGet;
        }

    }    
}

