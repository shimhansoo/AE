using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragonLaserSkill : PetProperty
{
    // ������ ���� ���� ������Ʈ ����
    public GameObject Laser = null;
    void Start()
    {
        // ��ų �ִϸ��̼� Ʈ����
        PetAnim.SetTrigger("isSkill");
    }

    // ������ On,Off�� �ִϸ��̼� �̺�Ʈ�� ȣ��

    void OnLaser()
    {
        // ������ Ŵ
        Laser.SetActive(true);
    }
    void OffLaser()
    {
        // ������ ��
        Laser.SetActive(false);
    }

    void OnAttack()
    {
        // ������ ũ�⸸ŭ ������ ����
        Collider2D[] hitEnemys = Physics2D.OverlapBoxAll(Laser.transform.position, new Vector2(5.0f,0.5f),0.0f, MonsterMask);
        foreach (Collider2D enemy in hitEnemys)
        {
            // �������� �������� ������
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(DragonSkillDamageW);  
        }       
    }
}
