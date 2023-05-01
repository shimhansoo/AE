using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EarthDragon : PetMoveMent
{
    // � �巡�� ��ų 1 ������Ʈ
    public GameObject EarthDragonSkill1;

    // � �巡�� ��ų 2 ������Ʈ
    public GameObject EarthDragonSkill2;

    // ù ���� ����
    State DragonState = State.Creat;

    void Start()
    {
        // �����ǰ� ù ���� �븻
        ChangeState(State.Normal);
    }

    // � �巡�� ���� ���� �Լ�.
    void ChangeState(State s)
    {
        if (DragonState == s) return;
        DragonState = s;
        switch (DragonState)
        {
            // �븻 �����϶��� �÷��̾ ����ٴϰԲ�
            case State.Normal:
                StopAllCoroutines();
                StartCoroutine(DragonMoving());
                break;
            // ��Ʋ ���� ����.
            case State.Battle:
                StopAllCoroutines();
                StartCoroutine(Attacking(TarGet));
                break;
            default:
                Debug.Log("���� ���� �Դϴ�.");
                break;
        }
    }

    // � �巡�� ���� ��� ���� �Լ�.
    void StateProcess()
    {
        switch (DragonState)
        {
            case State.Normal:
                break;
            case State.Battle:
                break;
            default:
                Debug.Log("���� ���� �Դϴ�.");
                break;
        }
    }

    void Update()
    {
        StateProcess();

        // � �巡�� 3�� ��ų 
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
        }

        // � �巡�� 4�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
        }
    }
}

