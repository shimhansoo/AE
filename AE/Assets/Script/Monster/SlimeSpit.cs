using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpit : Monster
{
    SpriteRenderer renderer;
    public static MonsterProperty instance;
    Transform myParent;
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Moving());
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Moving()
    {
        Vector2 dir = myTarget.position - transform.position;
        dir.Normalize();
        while (true)
        {
            transform.Translate(dir * MoveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
