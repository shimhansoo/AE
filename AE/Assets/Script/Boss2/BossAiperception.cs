using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface BossIPerception
{
    void FindTarget(Transform target);
    void LostTarget(Transform target);
}


public class BossAiPerception : MonoBehaviour
{
    public List<Transform> myEnemylist = new List<Transform>();
    public LayerMask targetMask;
    BossIPerception myParent = null;
    Transform myTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        myParent = GetComponentInParent<BossIPerception>();
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

}
