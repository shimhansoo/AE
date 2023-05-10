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


    // ��Ʋ �ý��� ��ũ��Ʈ�� �����ϱ����� ����.
    public BattleSystem testClass;

    public LayerMask Test;

    // ���� Ÿ��
    public Transform NowTarget;

    // ù ���� ����
    State DragonState = State.Creat;

    void Start()
    {
        // �����ǰ� ù ���� �븻
        ChangeState(State.Normal);
        testClass = player.parent.GetComponent<BattleSystem>();
    }


    // ��ũ �巡�� ���� ���� �Լ�.
    void ChangeState(State s)
    {
        if (DragonState == s) return;
        DragonState = s;
        switch (DragonState)
        {
            // �븻 �����϶��� �÷��̾ ����ٴϰԲ�
            case State.Normal:
                if (coAttacking != null) StopCoroutine(coAttacking);
                StartCoroutine(DragonMoving());
                break;
            // ��Ʋ ���� ����.
            case State.Battle:
                if (coDragonMoving != null) StopCoroutine(coDragonMoving);
                StartCoroutine(Attacking(TarGet));
                break;
            default:
                Debug.Log("���� ���� �Դϴ�.");
                break;
        }
    }

    // ��ũ �巡�� ���� ���� ��� �Լ�.
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
                Debug.Log("���� ���� �Դϴ�.");
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
        // ��ũ �巡�� 3�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(DarkDragonSkill1, transform.position, Quaternion.identity);
        }
        
        // ��ũ �巡�� 4�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(rayHitCowPos.point);
            if(rayHitCowPos)Instantiate(DarkDragonSkill2, rayHitCowPos.point + new Vector2(0, 0.5f), Quaternion.identity);
        }
    }

}

