using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.Events;*/

public class FireDragon : PetMoveMent
{
    public Transform NowTarget;

    // ��Ʋ �ý��� ��ũ��Ʈ�� �����ϱ����� ����.
    public BattleSystem testClass;

    // ���̾� �巡�� ��ų 1 ������Ʈ
    public GameObject FireDragonSprit1;
    public GameObject FireDragonSprit2;
    public GameObject FireDragonSprit3;
    public GameObject FireDragonSprit4;
    // ���̾� �巡�� ��ų 1 �ӽ� ��
    public bool isspirit = true;

    // ���̾� �巡�� ��ų 2 ������Ʈ
    public GameObject FireDragonSkill2;

    // ù ���� ����
    [SerializeField]State DragonState = State.Creat;

    void Start()
    {        
        // �����ǰ� ù ���� �븻
        ChangeState(State.Normal);
        testClass = player.parent.GetComponent<BattleSystem>();
    }

    // ���̾� �巡�� ���� ���� �Լ�.
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
                NowTarget = TarGet;
                break;
            default:
                Debug.Log("���� ���� �Դϴ�.");
                break;
        }
    }

    // ���̾� �巡�� ���� ��� ���� �Լ�.
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
    // Update is called once per frame
    void Update()
    {
        // ��Ʋ�ý��� ��ũ��Ʈ�� ������
        
        

        StateProcess();

        // ���̾� �巡�� 3�� ��ų
        if(Input.GetKeyDown(KeyCode.Alpha3) && isspirit)
        {
            isspirit = false;
            Instantiate(FireDragonSprit1, transform.position, Quaternion.identity);
            Instantiate(FireDragonSprit2, transform.position, Quaternion.identity);
            Instantiate(FireDragonSprit3, transform.position, Quaternion.identity);
            Instantiate(FireDragonSprit4, transform.position, Quaternion.identity);
        }

        // ���̾� �巡�� 4�� ��ų
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameObject test = Instantiate(FireDragonSkill2, transform.position, Quaternion.identity);
            test.GetComponent<DragonThrowSkill>().enabled=true;
            test.GetComponent<DragonThrowSkill>().TarGet = TarGet;
        }

    }    
}

