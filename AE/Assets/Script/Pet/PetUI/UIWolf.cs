using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWolf : PetProperty
{
    public Transform PlayerPos = null;
    public float TestTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToPos());
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = PlayerPos.position - transform.position;
        dir.Normalize();
        if (dir.x < 0.0f)
        {
            PetRenderer.flipX = true;
        }
        else
        {
            PetRenderer.flipX = false;
        }
        if (transform.position.x <= PlayerPos.position.x + 1.0f) StopAllCoroutines();
    }
    IEnumerator MoveToPos()
    {        
        while (true)
        {
            TestTime += Time.deltaTime;
            if (TestTime > 5.0f && transform.position.x > /*Vector2.zero.x*/PlayerPos.position.x + 1.0f)
            {
                transform.Translate(-Vector2.right * 2.0f * Time.deltaTime);
            }
            yield return null;
        }
    }
}
