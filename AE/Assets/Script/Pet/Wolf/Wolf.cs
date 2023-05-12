using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : PetMoveMent
{
    private void Start()
    {
        StartCoroutine(WolfMoving());
    }
}
