using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonsterAttack, IPerception
{
    public Transform attackTarget = null;
    public static Monster MonsterInstance;
    // 유한 상태기계
    public State myState = State.Create;
    public enum State
    {
        Create, Normal, Battle, Death
    }
    void ChangeState(State s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case State.Create:
                break;
            case State.Normal:
                StopAllCoroutines();
                StartCoroutine(Roaming());
                break;
            case State.Battle:
                StopAllCoroutines();
                OnTrace(myTarget);
                break;
            case State.Death:
                break;
        }   
    }
    void ProcessState()
    {
        switch (myState)
        {
            case State.Create:
                break;
            case State.Normal:
                break;
            case State.Battle:
                break;
            case State.Death:
                break;
        }
    }

    void Start()
    {
        MonsterInstance = this;
        Invoke("ChangeDirection", 5);
        ChangeState(State.Normal);
    }

    private void FixedUpdate()
    {
        AirCheck();
        CliffCheck();
    }

    void Update()
    {
        ProcessState();
    }
    // Find Target
    public void FindTarget(Transform target)
    {
        myTarget= target;
        attackTarget = myTarget;
        ChangeState(State.Battle);
    }
    // Lost Target
    public void LostTarget()
    {
        myTarget = null;
        attackTarget = null;
        coTrace = null;
        ChangeState(State.Normal);
    }
}
