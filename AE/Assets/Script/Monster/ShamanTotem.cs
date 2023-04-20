using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShamanTotem : MonsterMovement, IPerception
{
    public int SlowPercentage = 100;
    private float tmpMoveSpeed = -1f;
    GameObject slowDebuff = null;

    // Start is called before the first frame update
    void Start()
    {
        if(Monster.MonsterInstance.attackTarget != null) myTarget = Monster.MonsterInstance.attackTarget;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        SetForward(myTarget.position - transform.position);
    }
    public void FindTarget(Transform target)
    {
        myTarget = target;
        slowDebuff = target.GetComponent<Player>().DebuffIcon;
        StartSlowDebuff(target);
    }
    public void LostTarget(Transform target)
    {
        EndSlowDebuff(target);
    }
    void StartSlowDebuff(Transform target)
    {

        if (slowDebuff != null) return;
        if ((targetMask & 1 << target.gameObject.layer) != 0)
        {
            target.GetComponent<Player>().DebuffIcon = slowDebuff = Instantiate(Resources.Load("Monster/Totem_DeBuff"), target) as GameObject;
            slowDebuff.transform.position = new Vector2(target.position.x, target.position.y + 1f);
            if (tmpMoveSpeed < 0.0f)
            {
                tmpMoveSpeed = target.GetComponent<Player>().playerMoveSpeed;
            }
            target.GetComponent<Player>().playerMoveSpeed *= ((100 - SlowPercentage) * 0.01f);
        }
    }
    void EndSlowDebuff(Transform target)
    {
        if (slowDebuff != null) Destroy(slowDebuff);
        if (tmpMoveSpeed > 0.0f)
        {
            target.GetComponent<Player>().playerMoveSpeed = tmpMoveSpeed;
            tmpMoveSpeed = -1f;
        }
    }
}
