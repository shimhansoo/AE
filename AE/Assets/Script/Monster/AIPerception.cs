using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPerception
{
    void FindTarget(Transform target);
    void LostTarget(Transform target);
}
public interface ITotem
{
    void SetDebuffTime(float time);
    void EndDebuff();
}

public class AIPerception : MonoBehaviour
{
    public LayerMask targetMask;
    IPerception myParent = null;
    ITotem myTotem = null;
    Transform myTarget = null;
    bool isPlayerIn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myParent = GetComponentInParent<IPerception>();
        myTotem = GetComponentInParent<ITotem>();
    }
    private void FixedUpdate()
    {
        if (isPlayerIn)
        {
            TotemDebuffIcon.SlowInst.SetDebuffTime(TotemDebuffIcon.SlowInst.slowDebuffTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((targetMask & 1 << collision.gameObject.layer) != 0)
        {
            if (myTarget == null)
            {
                if(myTotem != null)isPlayerIn = true;
                myTarget = collision.transform;
                myParent.FindTarget(myTarget);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((targetMask & 1 << collision.gameObject.layer) != 0)
        {
            if (myTarget == collision.transform)
            {
                isPlayerIn = false;
                myTarget = null;
                myParent.LostTarget(collision.transform);
            }
        }
    }
}
