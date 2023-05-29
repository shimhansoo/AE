using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

[RequireComponent(typeof(Rigidbody2D), (typeof(BoxCollider2D)))]



public class Boss2 : Boss2_Atk, GameManager.IPerception, GameManager.IBattle
{
    
    public static Boss2 MonsterInstance;
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
        
        if(this.curHp <=0 && this.bossDie == false)
        {
            StartCoroutine(Death());
        }
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
   public void OnAttack()
    {
        myTarget.GetComponent<IBattle>()?.OnTakeDamage(attackDamage);
    }
    public void OnSmash()
    {
        myTarget.GetComponent<IBattle>()?.OnTakeDamage(SmashDamage);
    }
    public void OnSkill()
    {
        myTarget.GetComponent<IBattle>()?.OnTakeDamage(SkillCooltime);
       

    }
    public void OnBreath()
    {
        myTarget.GetComponent<IBattle>()?.OnTakeDamage(BreathDamage);
    }
    public bool isLive
    {
        
       
            get => myState != State.Death;
        
    }
    
    public void OnTakeDamage(float dmg)
    {
        curHp -= dmg;

        myAnim.SetTrigger("OnDamageColor");
        if (!Mathf.Approximately(curHp, 0f))
        {
            if (!myAnim.GetBool("isAttacking"))
                myAnim.SetTrigger("OnDamage");
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
