using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SlimeSpit : MonsterProperty
{
    public UnityEvent OnHitFunc;
    public Monster myParent = null;

    private void Awake()
    {
        myParent = GetComponentInParent<Monster>();
    }
    void Start()
    {
        StartCoroutine(Moving());
        this.attackPoint = myParent.attackPoint;
        transform.SetParent(null);
    }

    void Update()
    {
        
    }
    IEnumerator Moving()
    {
        float playTime = 0.0f;
        Vector2 dir = myParent.attackTarget.position - transform.position;
        dir.Normalize();
        float angle = Vector2.Angle(transform.right, dir);
        transform.Rotate(0, 0, angle);
        if (dir.x < 0.0f) myRenderer.flipY = true;

        while (true)
        {
            playTime += Time.deltaTime;
            if (playTime > 3f) Destroy(gameObject);
            transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);

            yield return null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopAllCoroutines();
        myAnim.SetTrigger("OnHit");
        if ((1 << collision.gameObject.layer & targetMask) != 0)
        {
            collision.transform.GetComponent<Player>().OnTakeDamage(attackPoint);
        }
    }
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
    void OnHit()
    {
        OnHitFunc?.Invoke();
    }
}
