using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardMagicCircle : MonoBehaviour
{
    Vector3 dir = new Vector3(0, 0, 180f);
    float destroyTime = 0;
    void Update()
    {
        transform.Rotate(dir * Time.deltaTime,Space.World);
        destroyTime += Time.deltaTime;
        if(destroyTime > 5.0f)
        {
            Destroy(gameObject);
        }
    }
}
