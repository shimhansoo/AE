using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

[RequireComponent(typeof(Rigidbody2D), (typeof(BoxCollider2D)))]

public class BossMonster : Boss_Attk, GameManager.IPerception, GameManager.IBattle
{
   
   
    public static BossMonster MonsterInstance;
    public bool bossDie = false;
    public System.Action onDie;

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
        myTarget= target;
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
    public void OnAttack()
    {
        myTarget.GetComponent<IBattle>()?.OnTakeDamage(attackDamge);
        


    }
    public void OnSwing()
    {
        myTarget.GetComponent<IBattle>()?.OnTakeDamage(SwingDamage);
    }
    public void OnEarth()
    {
        myTarget.GetComponent<IBattle>()?.OnTakeDamage(EarthDamage);
    }
    // IBattle
    public bool isLive
    {
        get => myState != State.Death;
    }
    public void OnTakeDamage(float dmg)
    {
        curHp -= dmg;

        myAnim.SetTrigger("OnDamage");
        if (!Mathf.Approximately(curHp, 0f))
            {
           if (myAnim.GetBool("isAttacking"))
                myAnim.SetTrigger("BossDamageColor");
        }
        
        else
        { 
        Collider2D[] colList = transform.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D col in colList) col.enabled = false;
        myRigid.simulated = false;
        ChangeState(State.Death);
         }
    }

    IEnumerator Death()
    {
        this.myAnim.SetTrigger("Death");
        this.bossDie = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
   

} 
    
   


