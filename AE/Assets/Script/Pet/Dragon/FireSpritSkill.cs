using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireSpritSkill : PetMoveMent
{
    public UnityEvent FireSpritReset = null;

    public float ThrowSpeed = 3.0f;
    public int Count = 0;
    public int CountCount = 0;
    bool Shooting = true;
    void Update()
    {
        if (transform.parent != null)
        {
          if (GetComponentInParent<FireDragon>().TarGet != null)
          {
              if (Input.GetKeyDown(KeyCode.Alpha3) && Count <CountCount) ++Count;
          }
        }
        if (Count == CountCount && Shooting)StartCoroutine(ThrowSkill());
    }
    IEnumerator ThrowSkill()
    {
        Shooting = false;
        TarGet = GetComponentInParent<FireDragon>().TarGet;
        Vector2 dir = TarGet.position - transform.position;
        float delta = ThrowSpeed * Time.deltaTime;
        while (true)
        {
            gameObject.transform.SetParent(null);
            if (TarGet == null)
            {
                FireSpritReset?.Invoke();
                Destroy(gameObject);
            }
            else if (Mathf.Abs(TarGet.position.x - transform.position.x) < 0.5f && Mathf.Abs(TarGet.position.y - transform.position.y) < 0.5f)
            {
                FireSpritReset?.Invoke();
                SkillDamage(10.0f);
                Destroy(gameObject);
            }
            else transform.Translate(dir * delta);
            yield return null;
        }
        
    }
}
