using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), (typeof(CircleCollider2D)))]
public class FireDamage : Boss2Property
{
    public UnityEvent OnHitFunc;
    public Boss2 myParent = null;

    private void Awake()
    {
        myParent = GetComponentInParent<Boss2>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Moving());
        this.SmashDamage = myParent.SmashDamage / 2;
        transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Moving()
    {
        float playTime = 0.0f;
        Vector2 dir = myParent.attackTarget.position - transform.position;
        dir.Normalize();
        float angle = Vector2.Angle(transform.right, dir);
        if (dir.y < 0.0f) angle = -angle;
        transform.Rotate(0, 0, angle);
        if (dir.x < 0.0f) myRenderer.flipY = true;

        while (true)
        {
            playTime += Time.deltaTime;
            if (playTime > 2f) Destroy(gameObject);
            transform.Translate(dir * MoveSpeed * Time.deltaTime, Space.World);

            yield return null;
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
