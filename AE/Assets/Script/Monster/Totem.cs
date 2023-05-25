using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Totem : MonsterMovement, GameManager.IPerception, GameManager.ITotem, GameManager.IBattle
{
    public bool isSlow = false;
    public float slowDebuffTime = 3.0f;
    GameObject slowDebuff = null;

    // Start is called before the first frame update
    void Start()
    {
        if (Monster.MonsterInstance.attackTarget != null) myTarget = Monster.MonsterInstance.attackTarget;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        SetForward(myTarget.position - transform.position); // �÷��̾ �ٶ󺸱�
    }
    // interface IPerception
    public void FindTarget(Transform target)    // �÷��̾ ã���� ���ο� ����� ����
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
    void StartSlowDebuff(Transform target)  // ���ο� ����� ����
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
