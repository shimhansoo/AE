using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProperty : MonoBehaviour
{
    [Header("Status")]
    public float maxHp = 100f;  // 몬스터의 최대 체력
    public float _curHp = -1f;
    public float regenHp = 1f;  // 몬스터의 체력 재생량
    public float moveSpeed = 1.0f;    // 몬스터의 이동 속도
    public float attackDamage = 3.0f;    // 몬스터의 공격력
    public float autoAttackRange = 2.0f;    // 몬스터의 공격 사거리
    public float attackDelay = 3.0f;    // 몬스터의 공격 딜레이
    
    protected float playTime = 0.0f;    // 공격 딜레이 검사할 변수

    protected Transform TextArea;   // 데미지를 출력할 위치

    [Header("Target")]
    public Transform myTarget = null; // 타겟 저장
    public LayerMask targetMask;   // 타겟 레이어 지정
    [HideInInspector]public Transform attackTarget = null;

    [Header("RayCast")]
    public Transform myRightRayPos = null;  // 우측 레이 위치
    protected RaycastHit2D rightRay;
    public Transform myLeftRayPos = null;   // 좌측 레이 위치
    protected RaycastHit2D leftRay;
    public LayerMask groundMask;    // 땅 체크

    [Header("State")]
    public State myState = State.Create;
    public enum State
    {
        Create, Normal, Battle, Death
    }

    protected float curHp
    {
        get
        {
            // _curHp의 초기값이 음수, MaxHp 대입
            if (_curHp < 0.0f || _curHp > maxHp) _curHp = maxHp;
            return _curHp;
        }
        // _curHp 값의 범위 지정
        set
        {
            _curHp = Mathf.Clamp(value, 0.0f, maxHp);
        }
    }

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

    // Get Collider2D
    Collider2D _collider;
    protected Collider2D myCollider
    {
        get
        {
            if(_collider == null)
            {
                _collider = GetComponent<Collider2D>();
            }return _collider;
        }
    }
}
