using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragonSkullSkill : PetMoveMent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TarGet == null) Destroy(gameObject);
        else TartGetSkill();
    }
    void TartGetSkill()
    {
        transform.position = TarGet.position + new Vector3(0, 0.5f, 0);
        DurationCountTime += Time.deltaTime;
        if (TarGetSkillDuration < DurationCountTime)
        {
            Destroy(gameObject);
        }
    }
}
