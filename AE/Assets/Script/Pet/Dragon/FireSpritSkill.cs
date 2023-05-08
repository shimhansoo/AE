using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireSpritSkill : PetMoveMent
{
    public UnityEvent FireSpritReset = null;

    public float ThrowSpeed = 10.0f;
    public int Count = 0;
    public int CountCount = 0;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))++Count;
        if(Count == CountCount)
        {
            StopAllCoroutines();
            StartCoroutine(ThrowSkill());
        }        
    }
    IEnumerator ThrowSkill()
    {
        if (!TarGet)
        {
            TarGet = GetComponentInParent<FireDragon>().TarGet;
            if (TarGet == null)
            {
                --Count;
                StopAllCoroutines();
            }
        }
        gameObject.transform.SetParent(null);
        Vector2 dir = TarGet.position - transform.position;
        float delta = ThrowSpeed * Time.deltaTime;
        while (true)
        {
            transform.Translate(dir * delta);
            if (Mathf.Abs(dir.x ) < 0.5f)
            {
                FireSpritReset?.Invoke();
                SkillDamage(10.0f);
                Destroy(gameObject);                
            }
            yield return null;
        }
        
    }
}
