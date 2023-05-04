using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty : MonoBehaviour
{
    //ü�� ����
    protected float playerMaxHp = 100.0f;
    public float playerCurHp = 0;


    //�̵� ����
    protected Vector2 dir = Vector2.zero;
    public float playerMoveSpeed = 3.0f;
    public float playerCurrentMoveSpeed = 0.0f;
    public float additionalSpeed = 0.0f;

    //�뽬 ����
    protected float collTime = 0.0f;
    protected Vector2 frontVec = Vector2.zero;
    protected int dashCount = 0;

    //���� ����
    protected bool isJump = false;
    protected int playerLayer, groundLayer;
    protected RaycastHit2D rayHitLeft = new RaycastHit2D();
    protected RaycastHit2D rayHitRight = new RaycastHit2D();
    protected float jumpCool = 0.0f;
    public float playerJumpPower = 16.0f;
    public LayerMask groundMask;
    public GameObject dashEffect;

    //���� ����
    protected float attackTime = 0.0f;
    protected float attackSpeed = 1.0f;
    public float playerDamege = 25.0f;
    public Transform attackPoint;
    public float attackRange = 0.7f;
    public GameObject DebuffIcon = null;
    public LayerMask enemyLayers;

    // �巡�� ����
    public GameObject BasicDragon;
    public GameObject FireDragon;
    public GameObject EarthDragon;
    public GameObject DarkDragon;

    //property ����
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
