using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProperty : MonoBehaviour
{
    public float MoveSpeed = 1f;    // 몬스터의 이동 속도
    public Transform myTarget = null; // 타겟 저장
    public LayerMask targetMask;   // 타겟 레이어 지정

    // Get Rigidbody2D
    Rigidbody2D _rigid;
    protected Rigidbody2D myRigid
    {
        get
        {
            if(_rigid == null)
            {
                _rigid = GetComponent<Rigidbody2D>();
                if(_rigid == null)
                {
                    _rigid = GetComponentInChildren<Rigidbody2D>();
                }
            }return _rigid;
        }
    }

    // Get Animator
    Animator _anim;
    protected Animator myAnim
    {
        get
        {
            if(_anim == null)
            {
                _anim = GetComponent<Animator>();
                if(_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();
                }
            }return _anim;
        }
    }
}
