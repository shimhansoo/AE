using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireSpritSkill : PetMoveMent
{
    // 파이어 스피릿이 켜져있는지 확인할 딜리게이트 함수.
    public UnityEvent FireSpritReset = null;

    public int NowCount = 0;
    public int StartCount = 0;

    // 코루틴 중복 가동을 막기위한 bool값
    bool Shooting = true;

    void Update()
    {
        // 만약에 부모가 null이 아니라면
        if (transform.parent != null)
        {
            // 또한 만약에 FireDragon컴포넌트의 TarGet값이 null이 아니라면
          if (GetComponentInParent<FireDragon>().TarGet != null)
          {
                // 3번키를 눌렀을때 그리고 설정해둔 StartCount값보다 0초기값인 NowCount가 작다면 Count를 플러스
              if (Input.GetKeyDown(KeyCode.W) && NowCount < StartCount) ++NowCount;
          }
        }
        // 초기값이 0 인 카운트가 위에 구문으로 인해 설정해둔 카운트 값과 같고 위에 설정해둔 Shooting의 bool값이 true라면 ThrowSkill코루틴 실행.
        if (NowCount == StartCount && Shooting)StartCoroutine(ThrowSkill());
    }

    // 타겟을 향해 스킬이 날아가는 코루틴 함수.
    IEnumerator ThrowSkill()
    {
        // 코루틴 중복 가동을 막기위해 Shooting bool값을 false로 변경
        Shooting = false;
        // 타겟값을 FireDragon이 현재 치고 있는 몬스터 TarGet값을 받음
        TarGet = GetComponentInParent<FireDragon>().TarGet;
        // 타겟과 스킬의 포지션을 빼서 방향값 구함
        Vector2 dir = TarGet.position - transform.position;
        // 속도,거리값
        float delta = ThrowSkillSpeed * Time.deltaTime;
        while (true)
        {
            // 파이어 드래곤 과의 부모를 끊어줘야 이동할수있으니 부모값 null
            gameObject.transform.SetParent(null);
            // 타겟 값이 null이라면
            if (TarGet == null)
            {
                // 보류
                FireSpritReset?.Invoke();
                // 오브젝트 삭제
                Destroy(gameObject);
            }
            // 타겟 값이 null이 아니고 타겟포지션과 스킬오브젝트의 포지션을 뺀 x,y값이 0.5보다 가까워졌다면
            else if (Mathf.Abs(TarGet.position.x - transform.position.x) < 0.5f && Mathf.Abs(TarGet.position.y - transform.position.y) < 0.5f)
            {
                // 보류
                FireSpritReset?.Invoke();
                // 타겟한테 데미지
                SkillDamage(DragonSkillDamageW);
                // 오브젝트 삭제
                Destroy(gameObject);
            }
            // 타겟 값도 있고 타겟과의 x,y거리가 0.5보다 멀다면 이동.
            else transform.Translate(dir * delta);
            yield return null;
        }
        
    }
}
