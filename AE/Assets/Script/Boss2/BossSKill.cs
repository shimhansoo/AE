using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSKill : MonoBehaviour
{
    public enum Type
    {
        Damage
    }
    public LayerMask crashMask;
    public float damagePerSecond = 1.0f;
    public float Time = 3.0f;
    public Sprite[] imgList;

    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RemoveEffect());
    }
    

  
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator RemoveEffect()
    {
        yield return new WaitForSeconds(Time);
        Destroy(gameObject);
    }
}
