using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : PetMoveMent
{
    // ���̾� �巡�� ��ų 1 ������Ʈ
    public GameObject FireDragonSprit1;
    public GameObject FireDragonSprit2;
    public GameObject FireDragonSprit3;
    public GameObject FireDragonSprit4;

    // ���̾� �巡�� ��ų 2 ������Ʈ
    public GameObject FireDragonFireRing;

    void Start()
    {
        // �����ǰ� ù ���� �븻
        ChangeState(State.Normal);
        TarGetRepScript = player.parent.GetComponent<BattleSystem>();
    }

    void Update()
    {
        // �巡�� ���±�� ���� , ��ȯ �Լ�.
        StateProcess();

        // ���̾� �巡�� Q ��ų
        if (Input.GetKeyDown(KeyCode.Q) && SkillWCoolTime <= 0.0f && TarGet != null)
        {
            SkillWCoolTime = 5.0f;
            GameObject FireThrowSkill = Instantiate(FireDragonFireRing, transform.position, Quaternion.identity);
            DragonThrowSkillTargetSetting(FireThrowSkill);
            StartCoroutine(SkillWCoolTimeCheck());
        }

        // ���̾� �巡�� W ��ų
        if(Input.GetKeyDown(KeyCode.W) && issprit && SkillQCoolTime <= 0.0f)
        {
            issprit = false;
            SkillQCoolTime = 10.0f;
            GameObject FireSpritSkill1 = Instantiate(FireDragonSprit1, transform.position + new Vector3(0.5f,1.5f,0), Quaternion.identity, transform);
            GameObject FireSpritSkill2 = Instantiate(FireDragonSprit2, transform.position + new Vector3(-0.5f, 1.5f, 0), Quaternion.identity, transform);
            GameObject FireSpritSkill3 = Instantiate(FireDragonSprit3, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity, transform);
            GameObject FireSpritSkill4 = Instantiate(FireDragonSprit4, transform.position + new Vector3(-0.5f, 0.5f, 0), Quaternion.identity, transform);
            FireSpritSkill4.GetComponent<FireSpritSkill>().FireSpritReset.AddListener(FireSpiritResetFunc);
            StartCoroutine(SkillQCoolTimeCheck());
        }
    }

    // ���̾� �巡�� 3�� ��ų�ߺ���� ���� bool �� true��ȯ �Լ�.
    public void FireSpiritResetFunc()
    {
        issprit = true;
    }

    // ���̾� �巡�� 4����ų Ÿ�ټ���.
    void DragonThrowSkillTargetSetting(GameObject Target)
    {
        Target.GetComponent<DragonThrowSkill>().TarGet = TarGet;
    }
}

