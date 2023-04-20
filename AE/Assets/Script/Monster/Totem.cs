using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Totem : MonsterMovement, IPerception
{
    bool isSlow = false;
    public int SlowPercentage = 90;
    protected float tmpMoveSpeed = -1f;
    GameObject slowDebuff = null;
    TotemDebuffIcon totem;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        if(Monster.MonsterInstance.attackTarget != null) myTarget = Monster.MonsterInstance.attackTarget;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        SetForward(myTarget.position - transform.position); // 플레이어를 바라보기
    }
    public void FindTarget(Transform target)    // 플레이어를 찾으면 슬로우 디버프 시작
    {
        myTarget = target;
        slowDebuff = target.GetComponent<Player>().DebuffIcon;
        StartSlowDebuff(target);
    }
    public void LostTarget(Transform target)
    {
        totem.EndDebuff();
    }
    void StartSlowDebuff(Transform target)  // 슬로우 디버프 시작
    {
        if (slowDebuff != null) return;
        if ((targetMask & 1 << target.gameObject.layer) != 0)
        {
            if (!isSlow)
            {
                tmpMoveSpeed = target.GetComponent<Player>()._playerMoveSpeed;
                isSlow = true;
            }
            target.GetComponent<Player>().DebuffIcon = slowDebuff = Instantiate(Resources.Load("Monster/Totem_DeBuff"), target) as GameObject;
            //slowDebuff.transform.position = new Vector2(target.position.x, target.position.y + 1f);
            //target.GetComponent<Player>().playerMoveSpeed *= ((100 - SlowPercentage) * 0.01f);
        }
    }
    //void EndSlowDebuff(Transform target)    // 슬로우 디버프 끝
    //{
    //    if (slowDebuff != null)
    //    {
    //        Destroy(slowDebuff);
    //        slowDebuff = null;
    //        if (isSlow)
    //        {
    //            target.GetComponent<Player>().playerMoveSpeed = tmpMoveSpeed;
    //            isSlow = false;
    //        }
    //    }
        
    //}
}
