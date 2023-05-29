using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Boss2Property : MonoBehaviour
{
    [Header("Status")]
    public float maxHp = 100f;
    public float _curHp = -1f;
    public float MoveSpeed = 3.0f;    // 몬스터의 이동 속도
    public float attackRange = 1.0f;    // 몬스터의 공격 사거리
    public float attackDelay = 2.0f;    // 몬스터의 공격 딜레이
    public float attackDamage = 10.0f;   //몬스터의 공격력
    public float SmashDamage = 10.0f;
    public float BreathDamage = 3.0f;
    public float SkillCooltime = 20.0f;
    protected float playTime = 0.0f;    // 공격 딜레이 검사할 변수
    protected Transform TextArea;

    [Header("Target")]
    public Transform myTarget = null; // 타겟 저장
    public LayerMask targetMask;   // 타겟 레이어 지정
    [HideInInspector] public Transform attackTarget = null;
    [Header("RayCast")]
    public Transform myRightRayPos = null;
    protected RaycastHit2D rightRay;
    public Transform myLeftRayPos = null;
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
            if (_curHp < 0.0f || _curHp > maxHp) curHp = maxHp;
            return _curHp;
        }
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
            if (_rigid == null)
            {
                _rigid = GetComponent<Rigidbody2D>();
                if (_rigid == null)
                {
                    _rigid = GetComponentInChildren<Rigidbody2D>();
                }
            }
            return _rigid;
        }
    }

    // Get Animator
    Animator _anim;
    protected Animator myAnim
    {
        get
        {
            if (_anim == null)
            {
                _anim = GetComponent<Animator>();
                if (_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();
                }
            }
            return _anim;
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
    Collider2D _collider;
    protected Collider2D myCollider
    {
        get
        {
            if (_collider == null)
            {
                _collider = GetComponent<Collider2D>();
            }
            return _collider;
        }
    }
}
