using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProperty : MonoBehaviour
{
    public float MoveSpeed = 1.0f;    // ������ �̵� �ӵ�
    public float AttackRange = 2.0f;    // ������ ���� ��Ÿ�
    public float AttackDelay = 3.0f;    // ������ ���� ������
    public float AttackPoint = 10.0f;
    protected float playTime = 0.0f;    // ���� ������ �˻��� ����
    public Transform myTarget = null; // Ÿ�� ����
    public Transform myRightRayPos = null;
    public Transform myLeftRayPos = null;
    public LayerMask targetMask;   // Ÿ�� ���̾� ����
    public LayerMask groundMask;    // �� üũ
    public float damge = 10.0f;
    public float maxHp = 100.0f;
    public float _curHp = -1f;
   
  
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
}
