using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMoveMent : PetProperty /*, GameManager.IBattle*/
{
    private void Awake()
    {
        // �÷��̾� Ÿ�� ���ε� ��� �ӽ÷�
        GameObject PlayerPos = GameObject.Find("DragonTargetPlayerPos");
        player = PlayerPos.transform;

    }

    // �巡�� �Ϲ� ���� ������ ���� �Լ�.
    public void OnAttack()
    {
            TarGet.GetComponent<GameManager.IBattle>().OnTakeDamage(DragonATK);
    }

    // �巡�� ��ų ���� ������ ���� �Լ�.
    protected void SkillDamage(float Damage)
    {
        TarGet.GetComponent<GameManager.IBattle>().OnTakeDamage(Damage);
    }

    // �븻 ����.
    // �巡�� �븻 ������ �� �÷��̾� ����ٴϴ� �ڷ�ƾ. 
    protected IEnumerator DragonMoving()
    {

        while (true)
        {
            Vector2 dir = player.position - transform.position;
            dir.Normalize();
            PetRenderer.flipX = dir.x < 0.0 ? true : false;
            if (Mathf.Abs(transform.position.x - player.position.x) > 1.0f)
            {
                PetAnim.SetBool("isFlying", true);
                transform.Translate(dir * Time.deltaTime * DragonSpeed);
            }
            else
            {
                PetAnim.SetBool("isFlying", false);
            }
            yield return null;
        }
    }

    // ��Ʋ ����.
    // �巡�� ��Ʋ ������ �� ���� �ڷ�ƾ �Լ�.
    protected IEnumerator Attacking(Transform target)
    {
        while (true)
        {
            Vector2 dir = target.position - transform.position;
            dir.Normalize();
            float delta = (DragonSpeed * 2.0f) * Time.deltaTime;
            BasicAttackCoolTime += Time.deltaTime;
            if (BasicAttackCoolTime >= 5.0f)
            {
                PetRenderer.flipX = dir.x < 0.0f ? true : false;
                if (Mathf.Abs(target.position.x - transform.position.x) > 1.0f)
                {
                    PetAnim.SetBool("isAttacking", true);
                    transform.Translate(dir * delta);
                }
                else
                {
                        PetAnim.SetTrigger("isAttack");
                        BasicAttackCoolTime = 0.0f;
                }
            }
            else if (BasicAttackCoolTime >= 1.0f && BasicAttackCoolTime <= 5.0f) ComeBack();
            yield return null;
        }
    }

    // ��Ʋ ������ �� �����ϰ� �ٽ� ���ƿ��� �Ϲ� �Լ�.
    protected void ComeBack()
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

    // ���� �̵� �ڷ�ƾ �Լ�.
    protected IEnumerator WolfMoving()
    {
        while (true)
        {
            Vector2 dir = player.position - transform.position;
            float delta = WolfSpeed * Time.deltaTime;
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
                PetAnim.SetBool("isMoving", true);
                transform.Translate(dir * delta);
                Vector2 test = (Vector2)transform.position + Vector2.up; // �̰� 1�� �ʹ� ����.
                RaycastHit2D hit = Physics2D.Raycast(test, transform.right * -1.0f, 0.5f, GroundMask);
                RaycastHit2D hit2 = Physics2D.Raycast(test, transform.right * 1.0f, 0.5f, GroundMask);
                Debug.DrawRay(test, transform.right * 1.0f);
                Debug.DrawRay(test, transform.right * -1.0f);
                if (hit || hit2)
                {
                    transform.Translate(Vector2.up * PetJump * Time.deltaTime, Space.World);
                }
            }
            else
            {
                PetAnim.SetBool("isMoving", false);
            }
            // �÷��̾�� WolfTPdist ��ŭ �־����� �÷��̾�� �����̵�.
            if (Mathf.Abs(transform.position.x - player.position.x) > WolfTPdist)
            {
                PetAnim.SetTrigger("Telleport");
                transform.position = new Vector3(player.position.x, player.position.y + 1.0f, 0);
            }
            yield return null;
        }
    }
}
