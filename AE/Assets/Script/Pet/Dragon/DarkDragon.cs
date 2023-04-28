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

    // ù ���� ����
    State DragonState = State.Creat;

    void Start()
    {
        // �����ǰ� ù ���� �븻
        ChangeState(State.Normal);
    }

    private void Awake()
    {
        // �÷��̾� ���ε� ��ſ� �ӽ÷�.
        GameObject PlayerPos = GameObject.Find("DragonTarget");
        player = PlayerPos.transform;
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

    // ��ũ �巡�� ���� ���� ��� �Լ�.
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

        // ��ũ �巡�� 3�� ��ų
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(DarkDragonSkill1, transform.position, Quaternion.identity);
        }
        // ��ũ �巡�� 4�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
        }
    }
}

