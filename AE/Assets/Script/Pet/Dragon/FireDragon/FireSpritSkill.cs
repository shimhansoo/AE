using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireSpritSkill : PetMoveMent
{
    // ���̾� ���Ǹ��� �����ִ��� Ȯ���� ��������Ʈ �Լ�.
    public UnityEvent FireSpritReset = null;

    public int NowCount = 0;
    public int StartCount = 0;

    // �ڷ�ƾ �ߺ� ������ �������� bool��
    bool Shooting = true;

    void Update()
    {
        // ���࿡ �θ� null�� �ƴ϶��
        if (transform.parent != null)
        {
            // ���� ���࿡ FireDragon������Ʈ�� TarGet���� null�� �ƴ϶��
          if (GetComponentInParent<FireDragon>().TarGet != null)
          {
                // 3��Ű�� �������� �׸��� �����ص� StartCount������ 0�ʱⰪ�� NowCount�� �۴ٸ� Count�� �÷���
              if (Input.GetKeyDown(KeyCode.Alpha3) && NowCount < StartCount) ++NowCount;
          }
        }
        // �ʱⰪ�� 0 �� ī��Ʈ�� ���� �������� ���� �����ص� ī��Ʈ ���� ���� ���� �����ص� Shooting�� bool���� true��� ThrowSkill�ڷ�ƾ ����.
        if (NowCount == StartCount && Shooting)StartCoroutine(ThrowSkill());
    }

    // Ÿ���� ���� ��ų�� ���ư��� �ڷ�ƾ �Լ�.
    IEnumerator ThrowSkill()
    {
        // �ڷ�ƾ �ߺ� ������ �������� Shooting bool���� false�� ����
        Shooting = false;
        // Ÿ�ٰ��� FireDragon�� ���� ġ�� �ִ� ���� TarGet���� ����
        TarGet = GetComponentInParent<FireDragon>().TarGet;
        // Ÿ�ٰ� ��ų�� �������� ���� ���Ⱚ ����
        Vector2 dir = TarGet.position - transform.position;
        // �ӵ�,�Ÿ���
        float delta = ThrowSkillSpeed * Time.deltaTime;
        while (true)
        {
            // ���̾� �巡�� ���� �θ� ������� �̵��Ҽ������� �θ� null
            gameObject.transform.SetParent(null);
            // Ÿ�� ���� null�̶��
            if (TarGet == null)
            {
                // ����
                FireSpritReset?.Invoke();
                // ������Ʈ ����
                Destroy(gameObject);
            }
            // Ÿ�� ���� null�� �ƴϰ� Ÿ�������ǰ� ��ų������Ʈ�� �������� �� x,y���� 0.5���� ��������ٸ�
            else if (Mathf.Abs(TarGet.position.x - transform.position.x) < 0.5f && Mathf.Abs(TarGet.position.y - transform.position.y) < 0.5f)
            {
                // ����
                FireSpritReset?.Invoke();
                // Ÿ������ ������
                SkillDamage(DragonSkillDamage2);
                // ������Ʈ ����
                Destroy(gameObject);
            }
            // Ÿ�� ���� �ְ� Ÿ�ٰ��� x,y�Ÿ��� 0.5���� �ִٸ� �̵�.
            else transform.Translate(dir * delta);
            yield return null;
        }
        
    }
}
