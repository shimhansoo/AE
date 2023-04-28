using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill : PetProperty
{
    /*public Transform Target;
    public float Duration = 0.0f; // 지속시간 인스펙터 상에서 조절 가능.
    public float ThrowSpeed = 3.0f;
    private void Start()
    {        
    }
    private void Awake()
    {
        GameObject TargetPos = GameObject.Find("OrcWarrior");
        Target = TargetPos.transform;
    }
    private void Update()
    {
        ThrowSkill();
    }
    public void OnSkill()
    {
        transform.position = Target.position + new Vector3(0, 0.5f, 0);
        PetAnim.SetTrigger("isSkill");
    }
    void TartGetSkill()
    {
        transform.position = Target.position;
        DurationCountTime += Time.deltaTime;
        if (Duration > DurationCountTime)
        {
            Destroy(gameObject);
        }
    }
    void ThrowSkill()
    {
        Vector2 dir = Target.position - transform.position;
        float dist = dir.magnitude;
        dir.Normalize();        
        float delta = ThrowSpeed * Time.deltaTime;
        if(dist > delta)
        {
            dist = delta;
        }
        transform.Translate(dir * ThrowSpeed * Time.deltaTime);
        if (transform.position == Target.position || dir.x <= 0.5f)
        {
            Destroy(gameObject);
        }
    }*/
}
