using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardSkill2 : CharacterProperty
{
    public GameObject adogen;
    public void skill2() 
    {
       Instantiate(adogen, attackPoint.position, Quaternion.identity);
    }

}
