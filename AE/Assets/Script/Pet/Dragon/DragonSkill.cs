using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSkill : PetProperty
{
    public Transform Target;
    public void OnSkill()
    {
        transform.position = Target.position + new Vector3(0, 0.5f, 0);
        PetAnim.SetTrigger("isSkill");
    }
}
