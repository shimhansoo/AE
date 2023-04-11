using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpit : Monster
{
    SpriteRenderer renderer;
    public GameObject myParent;
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
        Vector2 dir = MonProInst.myTarget.position - transform.position;
        dir.Normalize();
        float angle = Vector2.Angle(transform.right, dir);
        transform.Rotate(0,0,angle);

        while (true)
        {
            transform.Translate(dir * MoveSpeed * Time.deltaTime, Space.World);
            
            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
