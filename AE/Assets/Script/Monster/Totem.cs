using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Totem : MonsterMovement, IPerception, ITotem
{
    public bool isSlow = false;
    public int SlowPercentage = 90;
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
        SetForward(myTarget.position - transform.position); // 플레이어를 바라보기
    }
    // interface IPerception
    public void FindTarget(Transform target)    // 플레이어를 찾으면 슬로우 디버프 시작
    {
        myTarget = target;
        slowDebuff = target.GetComponent<Player>().DebuffIcon;
        StartSlowDebuff(target);
    }
    public void LostTarget(Transform target)
    {
        EndDebuff();
    }
    // interface ITotem
    public void SetDebuffTime(float time)
    {
        TotemDebuffIcon.SlowInst.SetBuffTime(time);
    }
    public void EndDebuff()
    {
        TotemDebuffIcon.SlowInst.CheckTime();
        isSlow = false;
    }
    void StartSlowDebuff(Transform target)  // 슬로우 디버프 시작
    {
        if (slowDebuff != null) return;
        if (!isSlow)
        {
            if ((targetMask & 1 << target.gameObject.layer) != 0)
            {
                target.GetComponent<Player>().DebuffIcon = slowDebuff = Instantiate(Resources.Load("Monster/Totem_DeBuff"), target) as GameObject;
                SetDebuffTime(slowDebuffTime);
                isSlow = true;
            }
        }
    }
}
