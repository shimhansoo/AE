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
    [SerializeField] bool _isSprit = true;
    public bool isspirit
    {
        get => _isSprit;
        set
        {
            _isSprit = value;
        }
    }

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
        StateProcess();

        // 파이어 드래곤 3번 스킬
        if(Input.GetKeyDown(KeyCode.Alpha3) && isspirit)
        {
            if(isspirit)isspirit = false;
            GameObject FireSpritSkill1 = Instantiate(FireDragonSprit1, transform.position + new Vector3(0.5f,1.5f,0), Quaternion.identity, transform);
            GameObject FireSpritSkill2 = Instantiate(FireDragonSprit2, transform.position + new Vector3(-0.5f, 1.5f, 0), Quaternion.identity, transform);
            GameObject FireSpritSkill3 = Instantiate(FireDragonSprit3, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity, transform);
            GameObject FireSpritSkill4 = Instantiate(FireDragonSprit4, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity, transform);
            DragonFireSpritSkillTargetSetting(FireSpritSkill1);
            DragonFireSpritSkillTargetSetting(FireSpritSkill2);
            DragonFireSpritSkillTargetSetting(FireSpritSkill3);
            DragonFireSpritSkillTargetSetting(FireSpritSkill4);
            FireSpritSkill4.GetComponent<FireSpritSkill>().FireSpritReset.AddListener(FireSpiritReset);
        }

        // 파이어 드래곤 4번 스킬
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject FireThrowSkill = Instantiate(FireDragonSkill2, transform.position, Quaternion.identity);
            DragonThrowSkillTargetSetting(FireThrowSkill);
        }
    }
    public void FireSpiritReset()
    {
        isspirit = true;
    }
    // 파이어 드래곤 3번스킬 타겟설정.
    void DragonFireSpritSkillTargetSetting(GameObject Target)
    {
        //Target.GetComponent<DragonThrowSkill>().enabled = true;
        Target.GetComponent<FireSpritSkill>().TarGet = TarGet;
    }
    // 파이어 드래곤 4번스킬 타겟설정.
    void DragonThrowSkillTargetSetting(GameObject Target)
    {
        //Target.GetComponent<DragonThrowSkill>().enabled = true;
        Target.GetComponent<DragonThrowSkill>().TarGet = TarGet;
    }
}

