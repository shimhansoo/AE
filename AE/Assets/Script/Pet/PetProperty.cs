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
    public float DragonATK = 15.0f; // �巡�� ���ݷ�
    public float CowRot = 0.0f; // ��ũ �巡�� ������ ��ų ī�� ȸ����
    public float DragonSkillDamageQ = 30.0f; // �巡�� Q��ų ������ ��
    public float DragonSkillDamageW = 50.0f; // �巡�� W��ų ������ ��
    public float DragonTargetSkillPosY = 0.5f; // �巡�� Ÿ�ٽ�ų ������ y ��

    // �ð�����
    public float TarGetSkillDuration = 3.0f; // Ÿ�� ��ų ���ӽð�
    public float DurationCountTime = 0.0f; // Ÿ�� ��ų ���ӽð� �� ��
    public float BasicAttackCoolTime = 5.0f; // �巡�� �⺻���� ��Ÿ��
    public float SkillQCoolTime = 0.0f; // �巡�� ��ų Q ��Ÿ��
    public float SkillWCoolTime = 0.0f; // �巡�� ��ų W ��Ÿ��

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
    public LayerMask ItemMask; // ������ ����ũ

    // bool ��
    protected bool issprit = true; // ���̾� �巡�� ���Ǹ� ��ų �ߺ���� ���� bool ��.

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
