using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.Events;*/

public class FireDragon : PetMoveMent
{
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
                break;
            case State.Battle:
                break;
            default:
                Debug.Log("���� ���� �Դϴ�.");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
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
            Instantiate(FireDragonSkill2, transform.position, Quaternion.identity);
        }

    }    
}

