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
                StartCoroutine(DragonMoving());
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

    IEnumerator DragonMoving()
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
                transform.Translate(dir * Time.deltaTime * PetSpeed);
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
        
        float CoolTime = 2.0f;
        while (true)
        {            
            Vector2 dir = target.position - transform.position;
            dir.Normalize();
            float delta = (PetSpeed * 2.0f) * Time.deltaTime;
            if(dir.x < 0.0f)
            {
                PetRenderer.flipX = true;
            }
            else
            {
                PetRenderer.flipX = false;
            }
            if (Mathf.Abs(target.position.x - transform.position.x) > 1.3f)
            {
                transform.Translate(dir * delta );
            }
            else
            {
                CoolTime += Time.deltaTime;
                if (CoolTime >= 2.0f)
                {
                    PetAnim.SetTrigger("isAttack");
                    CoolTime = 0.0f;
                }
            }

            //if(대상이 죽어서 타겟이 널값이라면) 스테이트 체인지 노말.
            yield return null;
        }
    }
}
