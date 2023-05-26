using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : MonsterMovement, GameManager.IPerception, GameManager.ITotem, GameManager.IBattle
{
    public bool isSlow = false;
    public float slowDebuffTime = 3.0f;
    GameObject slowDebuff = null;

    // Start is called before the first frame update
    void Start()
    {
        myTarget = transform.parent.GetComponent<Monster>().attackTarget;
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        SetForward(myTarget.position - transform.position); // 플레이어를 바라보기
    }
    // interface IPerception
    public void FindTarget(Transform target)    // 플레이어를 찾으면 슬로우 디버프 시작
    {
        myTarget = target;
        slowDebuff = target.GetComponent<CharacterProperty>().DebuffIcon;
        StartSlowDebuff(target);
        myAnim.SetBool("isActive", true);
    }
    public void LostTarget(Transform target)
    {
        EndDebuff();
    }
    // interface ITotem
    public void SetDebuffTime(float time)
    {
        TotemDebuffIcon.Inst.SetBuffTime(time);
    }
    public void EndDebuff()
    {
        TotemDebuffIcon.Inst.CheckTime();
        myAnim.SetBool("isActive", false);
        isSlow = false;
    }
    void StartSlowDebuff(Transform target)  // 슬로우 디버프 시작
    {
        if (slowDebuff != null) return;
        if (!isSlow)
        {
            if ((targetMask & 1 << target.gameObject.layer) != 0)
            {
                target.GetComponent<CharacterProperty>().DebuffIcon = slowDebuff = Instantiate(Resources.Load("Monster/Totem_DeBuff"), target) as GameObject;
                SetDebuffTime(slowDebuffTime);
                isSlow = true;
            }
        }
    }
    // Interface IBattle
    public bool isLive
    {
        get => !Mathf.Approximately(curHp, 0f);
    }
    public void OnTakeDamage(float dmg)
    {
        curHp -= dmg;
        myAnim.SetTrigger("OnDamage");
        if (Mathf.Approximately(curHp, 0f))
        {
            Collider2D[] colList = transform.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D col in colList) col.enabled = false;
            myRigid.simulated = false;
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        myAnim.SetTrigger("Death");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
