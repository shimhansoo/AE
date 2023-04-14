using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : PetProperty
{
    public Transform TarGet = null;
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
            if (dir.x < 0.0f)
            {
                PetRenderer.flipX = true;
            }
            else
            {
                PetRenderer.flipX = false;
            }
            if (Mathf.Abs(transform.position.x - player.position.x) > 1.0f)
            {
                PetAnim.SetBool("isFlying", true);
                transform.Translate(dir * Time.deltaTime * Speed);
            }
            else
            {
                PetAnim.SetBool("isFlying", false);
            }
            yield return null;
        }
    }

    IEnumerator Attacking(Transform target)
    {
        float CoolTime = 5.0f;
        while (true)
        {
            Vector2 dir = target.position - transform.position;
            dir.Normalize();
            float delta = (PetSpeed * 2.0f) * Time.deltaTime;
            CoolTime += Time.deltaTime;
            if (!PetAnim.GetBool("isAttacking") && CoolTime >= 5.0f)
            {
                if (dir.x < 0.0f)
                {
                    PetRenderer.flipX = true;
                }
                else
                {
                    PetRenderer.flipX = false;
                }
                if (Mathf.Abs(target.position.x - transform.position.x) > 1.3f)
                {
                    transform.Translate(dir * delta);
                }
                else
                {
                    if (CoolTime >= 5.0f)
                    {
                        PetAnim.SetTrigger("isAttack");
                        /*PetAnim.SetBool("isAttacking", true);*/
                        CoolTime = 0.0f;
                    }
                }
            }
            else
            {
                if (CoolTime >= 1.0f)
                {
                    if (CoolTime >= 5.0f)
                    {
                        PetAnim.SetBool("isAttacking", false);
                    }
                    ComeBack();
                }
            }
            /*
            else
            {
                if(Mathf.Abs(transform.position.x - player.position.x) > 1.0f)
                {
                    PetAnim.SetBool("isFlying", true);
                    transform.Translate(dir * Time.deltaTime * 2.0f);
                }
                else
                {
                    PetAnim.SetBool("isFlying", false);
                    PetAnim.SetBool("isSkilling", true);
                }
            }*/
            yield return null;
            //if(대상이 죽어서 타겟이 널값이라면) 스테이트 체인지 노말.
        }
    }
    void ComeBack()
    {
        Vector2 dir = player.position - transform.position;
        dir.Normalize();
        if (dir.x < 0.0f)
        {
            PetRenderer.flipX = true;
        }
        else
        {
            PetRenderer.flipX = false;
        }
        if (Mathf.Abs(transform.position.x - player.position.x) > 1.0f)
        {
            PetAnim.SetBool("isFlying", true);
            transform.Translate(dir * Time.deltaTime * 10.0f);
        }
        else
        {
            PetAnim.SetBool("isFlying", false);
        }/*

        if (Mathf.Abs(transform.position.x - player.position.x) <= 1.1f)
        {
            ChangeState(State.Battle);
        }*/
    }
}

