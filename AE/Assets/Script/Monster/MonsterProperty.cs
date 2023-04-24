using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProperty : MonoBehaviour
{
    public float maxHp = 100f;  // ������ �ִ� ü��
    public float _curHp = -1f;
    public float moveSpeed = 1.0f;    // ������ �̵� �ӵ�
    public float attackRange = 2.0f;    // ������ ���� ��Ÿ�
    public float attackDelay = 3.0f;    // ������ ���� ������
    public float attackPoint = 3.0f;    // ������ ���ݷ�
    protected float playTime = 0.0f;    // ���� ������ �˻��� ����
    public Transform myTarget = null; // Ÿ�� ����
    public Transform myRightRayPos = null;  // ���� ���� ��ġ
    public Transform myLeftRayPos = null;   // ���� ���� ��ġ
    public LayerMask targetMask;   // Ÿ�� ���̾� ����
    public LayerMask groundMask;    // �� üũ

    protected float curHp
    {
        get
        {
            // _curHp�� �ʱⰪ�� ����, MaxHp ����
            if (_curHp < 0.0f) _curHp = maxHp;
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
}
