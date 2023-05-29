using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty : MonoBehaviour
{
    //체력 관련
    public float playerMaxHp = 100.0f;
    public float _curHp = -1;
    public float playerCurHp
    {
        get
        {
            if (_curHp < 0 || _curHp > playerMaxHp) _curHp = playerMaxHp;
            return _curHp;
        }
        set
        {
            _curHp = Mathf.Clamp(value, 0.0f, playerMaxHp);
        }
    }

    //이동 관련
    protected Vector2 dir = Vector2.zero;
    protected bool canMove = true;
    protected Collider2D groundCheck;
    protected Collider2D groundUPCheck;
    public float playerMoveSpeed = 8.0f;
    [SerializeField]float _moveSpeed = -1.0f;
    public float playerCurrentMoveSpeed
    {
        get
        {
            if (_moveSpeed < 0) _moveSpeed = playerMoveSpeed;
            return _moveSpeed;
        }
        set
        {
            _moveSpeed = playerMoveSpeed + additionalSpeed;
        }
    }
    public float additionalSpeed = 0.0f;

    //대쉬 관련
    public float coolTime = 0.0f;
    protected Vector2 frontVec = Vector2.zero;
    public int dashCount = 0;
    protected bool canDash = true;
    protected float dashingPower = 15f;
    protected float dashingTime = 0.3f;

    //점프 관련
    protected bool isJump = false;
    protected int playerLayer, groundLayer;
    protected RaycastHit2D rayHitDownLeft = new RaycastHit2D();
    protected RaycastHit2D rayHitDownRight = new RaycastHit2D();
    protected float jumpCool = 0.0f;
    public float playerJumpPower = 16.0f;
    public LayerMask groundMask;

    //전투 관련
    protected float attackTime = 0.0f;
    protected float attackSpeed = 1.0f;
    public float playerDamege = 25f;
    public Transform attackPoint;
    public float attackRange = 0.7f;
    public GameObject DebuffIcon = null;
    public LayerMask enemyLayers;

    //property 관련
    Animator _anim = null;
    SpriteRenderer _renderer = null;
    Rigidbody2D _rigid = null;

    protected SpriteRenderer myRenderer
    {
        get
        {
            if (_renderer == null)
            {
                _renderer = GetComponent<SpriteRenderer>();
                if (_renderer == null)
                {
                    _renderer = GetComponentInChildren<SpriteRenderer>();
                }
            }
            return _renderer;
        }
    }

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
}
