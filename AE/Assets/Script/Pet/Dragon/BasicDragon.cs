using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicDragon : PetMoveMent
{
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
    }
}

