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

    // �巡�� float ��
    public float DragonSpeed = 5.0f; // �巡�� ���ǵ�
    public float ThrowSkillSpeed = 10.0f; // �巡�� ��ô��ų ���ǵ�
    public float DragonATK = 50.0f;
    // �ð�����
    public float TarGetSkillDuration = 3.0f; // Ÿ�� ��ų ���ӽð�
    public float DurationCountTime = 0.0f; // Ÿ�� ��ų ���ӽð� �� ��
    public float BasicAttackCoolTime = 5.0f; // �巡�� �⺻���� ��Ÿ��

    // �ӵ� ����
    public float WolfSpeed = 2.0f; // ���� ���ǵ�
    public float PetJump = 3.0f; // ���� ���� ��
    public float WolfTPdist = 5.0f; // ���� �ڷ���Ʈ �Ÿ�

    // ������Ʈ ���� ����.
    public Transform player = null;
    public Transform TarGet = null;
    public LayerMask GroundMask; // ���� �׶��� ����ũ

    // �ִϸ��̼� ����
    Animator _PetAnim;
    SpriteRenderer _PetRenderer;

    // �� �ִϸ��̼� �̳�Ǵ����
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

    // �� ������ �̳�Ǵ����
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
