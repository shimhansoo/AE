using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragonLaserSkill : PetProperty
{
    // 레이저 공격 범위 오브젝트 참조
    public GameObject Laser = null;
    void Start()
    {
        // 스킬 애니메이션 트리거
        PetAnim.SetTrigger("isSkill");
    }

    // 레이저 On,Off는 애니메이션 이벤트로 호출

    void OnLaser()
    {
        // 레이저 킴
        Laser.SetActive(true);
    }
    void OffLaser()
    {
        // 레이저 끔
        Laser.SetActive(false);
    }

    void OnAttack()
    {
        // 레이저 크기만큼 오버랩 생성
        Collider2D[] hitEnemys = Physics2D.OverlapBoxAll(Laser.transform.position, new Vector2(5.0f,0.5f),0.0f, MonsterMask);
        foreach (Collider2D enemy in hitEnemys)
        {
            // 오버랩에 닿았을경우 데미지
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(DragonSkillDamageW);  
        }       
    }
}
