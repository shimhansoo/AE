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
    [SerializeField] bool _isSprit = true;
    public bool isspirit
    {
        get => _isSprit;
        set
        {
            _isSprit = value;
        }
    }

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
        StateProcess();

        // ���̾� �巡�� 3�� ��ų
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

        // ���̾� �巡�� 4�� ��ų
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
    // ���̾� �巡�� 3����ų Ÿ�ټ���.
    void DragonFireSpritSkillTargetSetting(GameObject Target)
    {
        //Target.GetComponent<DragonThrowSkill>().enabled = true;
        Target.GetComponent<FireSpritSkill>().TarGet = TarGet;
    }
    // ���̾� �巡�� 4����ų Ÿ�ټ���.
    void DragonThrowSkillTargetSetting(GameObject Target)
    {
        //Target.GetComponent<DragonThrowSkill>().enabled = true;
        Target.GetComponent<DragonThrowSkill>().TarGet = TarGet;
    }
}

