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
    protected State DragonState = State.Creat; // 드래곤 첫 생성상태

    // 드래곤 float 값
    public float DragonSpeed = 5.0f; // 드래곤 스피드
    public float ThrowSkillSpeed = 10.0f; // 드래곤 투척스킬 스피드
    public float DragonATK = 15.0f; // 드래곤 공격력
    public float CowRot = 0.0f; // 다크 드래곤 레이저 스킬 카우 회전값
    public float DragonSkillDamageQ = 30.0f; // 드래곤 Q스킬 데미지 값
    public float DragonSkillDamageW = 50.0f; // 드래곤 W스킬 데미지 값
    public float DragonTargetSkillPosY = 0.5f; // 드래곤 타겟스킬 포지션 y 값

    // 시간관련
    public float TarGetSkillDuration = 3.0f; // 타겟 스킬 지속시간
    public float DurationCountTime = 0.0f; // 타겟 스킬 지속시간 비교 값
    public float BasicAttackCoolTime = 5.0f; // 드래곤 기본공격 쿨타임
    public float SkillQCoolTime = 0.0f; // 드래곤 스킬 Q 쿨타임
    public float SkillWCoolTime = 0.0f; // 드래곤 스킬 W 쿨타임

    // 속도 관련
    public float WolfSpeed = 2.0f; // 울프 스피드
    public float PetJump = 3.0f; // 울프 점프 힘
    public float WolfTPdist = 5.0f; // 울프 텔레포트 거리

    // 오브젝트 참조 관련
    public Transform player = null; // 드래곤 플레이어(주인)
    public Transform TarGet = null; // 드래곤 공격,스킬 타겟
    public Transform NowTarget; // 드래곤 일반공격 현재 타겟
    public GameObject SkillEffect; // 스킬 이펙트

    // 스크립트 참조
    protected BattleSystem TarGetRepScript; // 플레이어의 공격 타겟값을 받기위한 배틀 시스템 스크립트를 참조 변수.

    // Ray 변수
    protected RaycastHit2D rayHitCowPos; // 다크 드래곤 4번 스킬 CowPosition Ray

    // Layer 변수
    public LayerMask GroundMask; // 그라운드 마스크
    public LayerMask MonsterMask; // 몬스터 마스크
    public LayerMask ItemMask; // 아이템 마스크

    // bool 값
    protected bool issprit = true; // 파이어 드래곤 스피릿 스킬 중복사용 제한 bool 값.

    // 애니메이션 관련
    Animator _PetAnim; // 펫 애니메이터 참조 변수
    SpriteRenderer _PetRenderer; // 펫 렌더러 참조 변수

    // 펫 애니메이션 참조
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

    // 펫 렌더러 참조
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
