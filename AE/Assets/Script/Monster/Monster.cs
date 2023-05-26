using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), (typeof(BoxCollider2D)))]
public class Monster : MonsterAttack, GameManager.IPerception, GameManager.IBattle
{
    /* test */
    /* test */
    public static Monster MonsterInstance;
    float healingTime = 0;
    void ChangeState(State s)
    {
        if (myState == s) return;
        myState = s;
        switch (myState)
        {
            case State.Create:
                break;
            case State.Normal:
                if (!isLive) return;
                StopAllCoroutines();
                healingTime = 0f;
                StartCoroutine(Roaming());
                break;
            case State.Battle:
                if (!isLive) return;
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
                HpRegen();
                break;
            case State.Battle:
                break;
            case State.Death:
                break;
        }
    }

    void Start()
    {
        TextArea = GetComponentInChildren<Transform>().Find("DMGTextArea");
        MonsterInstance = this;
        ChangeDirection();
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
        GameObject obj = Instantiate(Resources.Load("UI/DmgText"), TextArea) as GameObject;
        obj.GetComponent<DamageText>().ChangeTextColor(dmg);
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

    void HpRegen()
    {
        if (Mathf.Approximately(curHp, maxHp)) return;
        healingTime += Time.deltaTime;
        if (healingTime > 3)
        {
            HpHealing(regenHp);
            healingTime = 0f;
        }
    }
    void HpHealing(float point)
    {
        if (Mathf.Approximately(curHp, maxHp)) return;
        GameObject obj = Instantiate(Resources.Load("UI/DmgText"), TextArea) as GameObject;
        obj.GetComponent<DamageText>().ChangeTextColor(point, 1);
        curHp += point;
        myAnim.SetTrigger("OnHealColor");
    }

    IEnumerator Death()
    {
        myAnim.SetTrigger("Death");
        yield return StartCoroutine(DroppingItem());
        yield return new WaitUntil(() => myAnim.GetBool("Done"));
        Destroy(gameObject);
    }
    WaitForSeconds waitCoinPop = new WaitForSeconds(0.05f);
    IEnumerator DroppingItem()
    {
        Vector2 orgPos = transform.position;
        int coinNum = Random.Range(1, 21);
        for (int i = 0; i < coinNum; i++)
        {
            // 나중에 ObjectPool 활용해서 구현할 것
            yield return waitCoinPop;
            GameObject coinObj = Instantiate(Resources.Load("Item/Coin"), orgPos, Quaternion.identity) as GameObject;
            coinObj.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 5f)), ForceMode2D.Impulse);
        }
        RandomItemDrop();
    }
    int probability = 0;
    void RandomItemDrop()
    {
        probability = Random.Range(0, 101);

        if (probability > 90)
        {
            Instantiate(Resources.Load("Item/BasicStaff(Normal)"), new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        }
        else if (probability > 80)
        {
            Instantiate(Resources.Load("Item/BasicSpear(Normal)"), new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        }
        else if (probability > 65)
        {
            Instantiate(Resources.Load("Item/Armor(Normal)"), new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        }
        else if (probability > 50)
        {
            Instantiate(Resources.Load("Item/BasicSword(Normal)"), new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        }
        else
        {
            return;
        }
    }
}
