using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AIPerception : MonoBehaviour
{
    public LayerMask targetMask;
    GameManager.IPerception myParent = null;
    GameManager.ITotem myTotem = null;
    Transform myTarget = null;
    bool isPlayerIn = false;

    // Start is called before the first frame update
    void Start()
    {
        myParent = GetComponentInParent<GameManager.IPerception>();
        myTotem = GetComponentInParent<GameManager.ITotem>();
    }
    private void FixedUpdate()
    {
        if (isPlayerIn)
        {
            TotemDebuffIcon.Inst.SetDebuffTime(TotemDebuffIcon.Inst.slowDebuffTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((targetMask & 1 << collision.gameObject.layer) != 0)
        {
            if (myTarget == null)
            {
                if (myTotem != null) isPlayerIn = true;   // 토템이면 isPlayerIn = true
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
