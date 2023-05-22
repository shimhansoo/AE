using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Boss2Property : MonoBehaviour
{
    [Header("Status")]
    public float maxHp = 100f;
    public float _curHp = -1f;
    public float MoveSpeed = 3.0f;    // ������ �̵� �ӵ�
    public float attackRange = 1.0f;    // ������ ���� ��Ÿ�
    public float attackDelay = 2.0f;    // ������ ���� ������
    public float attackDamage = 10.0f;   //������ ���ݷ�
    public float SmashDamage = 10.0f;
    public float BreathDamage = 3.0f;
    public float SkillCooltime = 20.0f;
    protected float playTime = 0.0f;    // ���� ������ �˻��� ����
    
    [Header("Target")]
    public Transform myTarget = null; // Ÿ�� ����
    public LayerMask targetMask;   // Ÿ�� ���̾� ����
    [HideInInspector] public Transform attackTarget = null;
    [Header("RayCast")]
    public Transform myRightRayPos = null;
    protected RaycastHit2D rightRay;
    public Transform myLeftRayPos = null;
    protected RaycastHit2D leftRay;
    public LayerMask groundMask;    // �� üũ


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
            if (_curHp < 0.0f) curHp = maxHp;
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
