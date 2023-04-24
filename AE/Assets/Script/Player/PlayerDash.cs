using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RemoveEffect());
    }

    void Update()
    {
        
    }
    IEnumerator RemoveEffect()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
