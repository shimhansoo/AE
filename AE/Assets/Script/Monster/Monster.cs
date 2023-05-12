using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), (typeof(BoxCollider2D)))]
public class Monster : MonsterAttack, GameManager.IPerception, GameManager.IBattle
{
    public static Monster MonsterInstance;
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
    public bool isLive
    {
        get => myState != State.Death;
    }
    public void OnTakeDamage(float dmg)
    {
        curHp -= dmg;
        myAnim.SetTrigger("OnDamageColor"); // 피격시 이미지의 색상을 바꿔주도록 Animator에서 설정
        
        if (!Mathf.Approximately(curHp, 0f))
        {
            if (!myAnim.GetBool("isAttacking"))
                myAnim.SetTrigger("OnDamage");  // 공격중엔 애니메이션 호출 안 함

            if (!myRenderer.flipX)
                myRigid.AddForce(-transform.right * 20f);    // 넉백
            else
                myRigid.AddForce(transform.right * 20f);
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
        myAnim.SetTrigger("Death");
        yield return StartCoroutine(DroppingItem());
        Destroy(gameObject);
    }
    IEnumerator DroppingItem()
    {
        Vector2 orgPos = transform.position;
        GameObject obj = new GameObject();
        obj.transform.position = orgPos;
        obj.name = $"{this.name}_Coin";
        int coinNum = Random.Range(1, 11);
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.05f);
            GameObject coinObj = Instantiate(Resources.Load("Item/Coin"), orgPos, Quaternion.identity, obj.transform) as GameObject;
            coinObj.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 5f)), ForceMode2D.Impulse);
        }
    }
}
