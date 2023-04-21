using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty : MonoBehaviour
{
    public float playerHp = 100.0f;
    // 플레이어의 기본 속도, 현재 속도, 속도 증감치
    public float playerMoveSpeed = 5.0f;
    public float playerCurrentMoveSpeed = 0.0f;
    public float additionalSpeed = 0.0f;

    public float playerDamege = 7.0f;
    public float playerJumpPower = 5.0f;
    Animator _anim = null;
    SpriteRenderer _renderer=null;

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
}
