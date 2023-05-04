using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonThrowSkill : PetMoveMent
{
    /*// 스킬 타겟 값.
    public Transform Target;*/
    public BattleSystem testClass;
    // 투척 스킬 이펙트가 있다면 참조.
    public GameObject Effect;
    private void Start()
    {
        //TarGet = player.parent.GetComponent<BattleSystem>().DragonTarget.transform;
    }
    private void Awake()
    {
    }
    private void Update()
    {
        ThrowSkill();
    }

    void ThrowSkill()
    {
        Vector2 dir = TarGet.position - transform.position;
        PetRenderer.flipX = dir.x > 0.0f ? true : false;        
        transform.Translate(dir * ThrowSkillSpeed * Time.deltaTime , Space.World);
        if (Mathf.Abs(dir.y) <= 1.0f && Mathf.Abs(dir.x)<= 1.0f)
        {
            /*// 이펙트 참조자가 있다면 공격 타겟에 스킬 오브젝트가 도착 후 스킬 타격 이펙트를 생성.
            if(Effect != null)
            {
            Instantiate(Effect, TarGet.position, Quaternion.identity);
            }*/
            // 투척 스킬 오브젝트 삭제.
            Destroy(gameObject);
        }
    }
}
