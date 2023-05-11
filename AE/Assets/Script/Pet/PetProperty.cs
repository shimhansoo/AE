using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetProperty : MonoBehaviour
{
    // �巡�� ���� ���
    protected enum State
    {
        Creat, Normal, Battle
    }
    protected State DragonState = State.Creat; // �巡�� ù ��������

    // �巡�� float ��
    public float DragonSpeed = 5.0f; // �巡�� ���ǵ�
    public float ThrowSkillSpeed = 10.0f; // �巡�� ��ô��ų ���ǵ�
    public float DragonATK = 50.0f; // �巡�� ���ݷ�
    public float CowRot = 0.0f; // ��ũ �巡�� ��ų 2 ī�� ȸ����
    public float DragonSkillDamage1 = 20.0f; // �巡�� ��ų ������ 1��
    public float DragonSkillDamage2 = 15.0f; // �巡�� ��ų ������ 2��
    public float DragonTargetSkillPosY = 0.5f; // �巡�� Ÿ�ٽ�ų ������ y ��

    // �ð�����
    public float TarGetSkillDuration = 3.0f; // Ÿ�� ��ų ���ӽð�
    public float DurationCountTime = 0.0f; // Ÿ�� ��ų ���ӽð� �� ��
    public float BasicAttackCoolTime = 5.0f; // �巡�� �⺻���� ��Ÿ��
    public float Skill1CoolTime = 0.0f; // �巡�� ��ų1(3��) ��Ÿ��
    public float Skill2CoolTime = 0.0f; // �巡�� ��ų2(4��) ��Ÿ��

    // �ӵ� ����
    public float WolfSpeed = 2.0f; // ���� ���ǵ�
    public float PetJump = 3.0f; // ���� ���� ��
    public float WolfTPdist = 5.0f; // ���� �ڷ���Ʈ �Ÿ�

    // ������Ʈ ���� ����
    public Transform player = null; // �巡�� �÷��̾�(����)
    public Transform TarGet = null; // �巡�� ����,��ų Ÿ��
    public Transform NowTarget; // �巡�� �Ϲݰ��� ���� Ÿ��
    public GameObject SkillEffect; // ��ų ����Ʈ

    // ��ũ��Ʈ ����
    protected BattleSystem TarGetRepScript; // �÷��̾��� ���� Ÿ�ٰ��� �ޱ����� ��Ʋ �ý��� ��ũ��Ʈ�� ���� ����.

    // Ray ����
    protected RaycastHit2D rayHitCowPos; // ��ũ �巡�� 4�� ��ų CowPosition Ray

    // Layer ����
    public LayerMask GroundMask; // �׶��� ����ũ
    public LayerMask MonsterMask; // ���� ����ũ

    // bool ��
    protected bool issprit = true; // ���̾� �巡�� ��ų 1 �ߺ���� ���� bool ��.

    // �ִϸ��̼� ����
    Animator _PetAnim; // �� �ִϸ����� ���� ����
    SpriteRenderer _PetRenderer; // �� ������ ���� ����

    // �� �ִϸ��̼� ����
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

    // �� ������ ����
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
