using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicDragon : PetMoveMent
{
    void Start()
    {
        // 생성되고 첫 상태 노말
        ChangeState(State.Normal);
        TarGetRepScript = player.parent.GetComponent<BattleSystem>();
    }

    void Update()
    {
        // 드래곤 상태기계 유지 , 변환 함수.
        StateProcess();
    }
}

