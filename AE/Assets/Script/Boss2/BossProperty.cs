using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProperty : MonoBehaviour
{
    public float MoveSpeed = 1.0f;    // ������ �̵� �ӵ�
    public float attackRange = 1.0f;    // ������ ���� ��Ÿ�
    public float attackDelay = 2.0f;    // ������ ���� ������
    public float attackDamge = 10.0f;   //������ ���ݷ�
    public float SwingDamage = 2.0f;
    public float EarthDamage = 20.0f;
    public GameObject EarthEffect;
    protected float playTime = 0.0f;    // ���� ������ �˻��� ����
    public Transform myTarget = null; // Ÿ�� ����
    public Transform myRightRayPos = null;
    public Transform myLeftRayPos = null;
    public LayerMask targetMask;   // Ÿ�� ���̾� ����
    public LayerMask groundMask;    // �� üũ
    
    public float maxHp = 100f;
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
