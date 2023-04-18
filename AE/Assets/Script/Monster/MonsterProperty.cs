using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProperty : MonoBehaviour
{
    public static MonsterProperty propertyInstance = null;

    public float MoveSpeed = 1.0f;    // 몬스터의 이동 속도
    public float AttackRange = 2.0f;    // 몬스터의 공격 사거리
    public float AttackDelay = 3.0f;    // 몬스터의 공격 딜레이
    protected float playTime = 0.0f;    // 공격 딜레이 검사할 변수
    public Transform myTarget = null; // 타겟 저장
    public Transform myRightRayPos = null;
    public Transform myLeftRayPos = null;
    public LayerMask targetMask;   // 타겟 레이어 지정
    public LayerMask groundMask;    // 땅 체크

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

    // Get SpriteRenderer
    SpriteRenderer _sprite;
    protected SpriteRenderer myRenderer
    {
        get
        {
            if (_sprite == null)
            {
                _sprite = GetComponent<SpriteRenderer>();
                if (_sprite == null)
                {
                    _sprite = GetComponentInChildren<SpriteRenderer>();
                }
            }
            return _sprite;
        }
    }
    private void Awake()
    {
        propertyInstance = this;
    }
}
