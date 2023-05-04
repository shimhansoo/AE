using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetProperty : MonoBehaviour
{
    // 드래곤 상태 기계
    protected enum State
    {
        Creat, Normal, Battle
    }

    // 드래곤 float 값
    public float DragonSpeed = 5.0f; // 드래곤 스피드
    public float ThrowSkillSpeed = 10.0f; // 드래곤 투척스킬 스피드
    public float DragonATK = 50.0f;
    // 시간관련
    public float TarGetSkillDuration = 3.0f; // 타겟 스킬 지속시간
    public float DurationCountTime = 0.0f; // 타겟 스킬 지속시간 비교 값
    public float BasicAttackCoolTime = 5.0f; // 드래곤 기본공격 쿨타임

    // 속도 관련
    public float WolfSpeed = 2.0f; // 울프 스피드
    public float PetJump = 3.0f; // 울프 점프 힘
    public float WolfTPdist = 5.0f; // 울프 텔레포트 거리

    // 오브젝트 참조 관련.
    public Transform player = null;
    public Transform TarGet = null;
    public LayerMask GroundMask; // 울프 그라운드 마스크

    // 애니메이션 관련
    Animator _PetAnim;
    SpriteRenderer _PetRenderer;

    // 펫 애니메이션 궷퀌풔눤퉈
    protected Animator PetAnim
    {
        get
        {
            if (_PetAnim == null)
            {
                _PetAnim = GetComponent<Animator>();
                if (_PetAnim == null)
                {
                    _PetAnim = GetComponentInChildren<Animator>();
                }
            }
            return _PetAnim;
        }
    }

    // 펫 렌더러 궷퀌풔눤퉈
    protected SpriteRenderer PetRenderer
    {
        get
        {
            if (_PetRenderer == null)
            {
                _PetRenderer = GetComponent<SpriteRenderer>();
                if (_PetRenderer == null)
                {
                    _PetRenderer = GetComponentInChildren<SpriteRenderer>();
                }
            }
            return _PetRenderer;
        }
    }

}
