using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonsterAttack, IPerception
{
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
        Invoke("ChangeDirection", 5);
        ChangeState(State.Normal);
    }

    private void FixedUpdate()
    {
        AirCheck();
    }

    void Update()
    {
        ProcessState();
    }
    // Find Target
    public void FindTarget(Transform target)
    {
        myTarget= target;
        ChangeState(State.Battle);
    }
    // Lost Target
    public void LostTarget()
    {
        myTarget = null;
        coTrace = null;
        ChangeState(State.Normal);
    }
    public void SlimeSpit()
    {
        GameObject obj = Instantiate(Resources.Load("Slime_Spit")) as GameObject;
        obj.transform.position = transform.Find("Spit").position;
    }
}
