using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dragon : PetProperty
{
    public Transform TarGet = null;
    public UnityEvent DragonSkill = null;
    public enum State
    {
        Creat, Normal, Battle
    }
    // Start is called before the first frame update
    public State DragonState = State.Creat;
    void Start()
    {
        ChangeState(State.Battle);
    }

    void ChangeState(State s)
    {
        if (DragonState == s) return;
        DragonState = s;
        switch (DragonState)
        {
            case State.Normal:
                StartCoroutine(DragonMoving(2.0f));
                break;
            case State.Battle:
                StopAllCoroutines();
                StartCoroutine(Attacking(TarGet));
                break;
            default:
                Debug.Log("없는 상태 입니다.");
                break;
        }
    }

    void StateProcess()
    {
        switch (DragonState)
        {
            case State.Normal:
                break;
            case State.Battle:
                break;
            default:
                Debug.Log("없는 상태 입니다.");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        StateProcess();
    }

    IEnumerator DragonMoving(float Speed)
    {

        while (true)
        {
            Vector2 dir = player.position - transform.position;
            dir.Normalize();
            PetRenderer.flipX = dir.x < 0.0 ? true : false;
            if (Mathf.Abs(transform.position.x - player.position.x) > 1.0f)
            {
                PetAnim.SetBool("isFlying", true);
                transform.Translate(dir * Time.deltaTime * Speed);
            }
            else
            {
                PetAnim.SetBool("isFlying", false);
            }
            if (TarGet != null)
            {
                ChangeState(State.Battle);
            }
            yield return null;
        }
    }

    IEnumerator Attacking(Transform target)
    {
        float CoolTime = 5.0f;
        float SkillCoolTime = 0.0f;
        while (true)
        {
            Vector2 dir = target.position - transform.position;
            dir.Normalize();
            float delta = (PetSpeed * 2.0f) * Time.deltaTime;
            CoolTime += Time.deltaTime;
            SkillCoolTime += Time.deltaTime;
            if (CoolTime >= 5.0f)
            {
                PetRenderer.flipX = dir.x < 0.0f ? true : false;
                if (Mathf.Abs(target.position.x - transform.position.x) > 1.3f)
                {
                    PetAnim.SetBool("isAttacking", true);
                    transform.Translate(dir * delta);
                }
                else
                {
                    if (CoolTime >= 5.0f)
                    {
                        PetAnim.SetTrigger("isAttack");
                        CoolTime = 0.0f;
                    }
                }
            }
            else if (CoolTime >= 1.0f) ComeBack();
            if (SkillCoolTime >= 5.0f && !PetAnim.GetBool("isAttacking"))
            {
                DragonSkill?.Invoke();
                PetAnim.SetTrigger("isSkill");
                SkillCoolTime = 0.0f;

            }
            if (TarGet == null) ChangeState(State.Normal);
            yield return null;
        }
    }
    void ComeBack()
    {
        Vector2 dir = player.position - transform.position;
        dir.Normalize();
        PetRenderer.flipX = dir.x < 0.0f ? true : false;
        if (Mathf.Abs(transform.position.x - player.position.x) > 1.0f)
        {
            PetAnim.SetBool("isFlying", true);
            transform.Translate(dir * Time.deltaTime * 10.0f);
        }
        else
        {
            PetAnim.SetBool("isAttacking", false);
            PetRenderer.flipX = TarGet.position.x - transform.position.x > 0.0f ? false : true;
            PetAnim.SetBool("isFlying", false);
        }
        if (transform.position.y - player.position.y > 0.5)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 3.0f);
        }
        else if (player.position.y - transform.position.y > 0.5)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 3.0f);
        }
    }
}

