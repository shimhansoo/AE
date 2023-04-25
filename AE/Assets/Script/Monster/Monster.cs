using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonsterMovement, GameManager.IPerception, GameManager.IBattle
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
                StopAllCoroutines();
                StartCoroutine(Death());
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
        myTarget = target;
        attackTarget = target;
        ChangeState(State.Battle);
    }
    // Lost Target
    public void LostTarget(Transform target)
    {
        myTarget = null;
        coTrace = null;
        ChangeState(State.Normal);
    }
    // IBattle
    public void OnTakeDamage(float dmg)
    {
        curHp -= dmg;
        if (!myAnim.GetBool("isAttacking"))
        {
            myAnim.SetTrigger("OnDamage");
            if (!myRenderer.flipX) myRigid.AddForce(-transform.right * 20f);
            else myRigid.AddForce(transform.right * 20f);
        }
        if (Mathf.Approximately(curHp, 0f))
        {
            Collider2D[] colList = transform.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D col in colList) col.enabled = false;
            myRigid.simulated = false;
            ChangeState(State.Death);
        }
    }

    IEnumerator Death()
    {
        myAnim.SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
