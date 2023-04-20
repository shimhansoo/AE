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
    Transform myTarget = null;
    Transform myTotem = null;
    // Start is called before the first frame update
    void Start()
    {
        myParent = GetComponentInParent<IPerception>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((targetMask & 1 << collision.gameObject.layer) != 0)
        {
            if (myTarget == null)
            {
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
                myTarget = null;
                myParent.LostTarget(collision.transform);
            }
        }
    }

    // 토템 디버프
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
