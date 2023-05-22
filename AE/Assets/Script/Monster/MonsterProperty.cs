using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MonsterProperty : MonoBehaviour
{
    [Header("Status")]
    public float maxHp = 100f;  // ������ �ִ� ü��
    public float _curHp = -1f;
    public float moveSpeed = 1.0f;    // ������ �̵� �ӵ�
    public float attackDamage = 3.0f;    // ������ ���ݷ�
    public float autoAttackRange = 2.0f;    // ������ ���� ��Ÿ�
    public float attackDelay = 3.0f;    // ������ ���� ������
    
    protected float playTime = 0.0f;    // ���� ������ �˻��� ����

    protected Transform TextArea;   // �������� ����� ��ġ

    [Header("Target")]
    public Transform myTarget = null; // Ÿ�� ����
    public LayerMask targetMask;   // Ÿ�� ���̾� ����
    [HideInInspector]public Transform attackTarget = null;

    [Header("RayCast")]
    public Transform myRightRayPos = null;  // ���� ���� ��ġ
    protected RaycastHit2D rightRay;
    public Transform myLeftRayPos = null;   // ���� ���� ��ġ
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
            // _curHp�� �ʱⰪ�� ����, MaxHp ����
            if (_curHp < 0.0f || _curHp > maxHp) _curHp = maxHp;
            return _curHp;
        }
        // _curHp ���� ���� ����
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
