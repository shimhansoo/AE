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
       // StartCoroutine(Move());
      //  this.SmashDamage = myParent.SmashDamage;
        transform.SetParent(null);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
   /* IEnumerator Move()
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

    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & groundMask) != 0) return;
        StopAllCoroutines();
        myAnim.SetTrigger("OnHit");
        if ((1 << collision.gameObject.layer & targetMask) != 0)
        {
            collision.transform.GetComponent<GameManager.IBattle>().OnTakeDamage(attackDamage);
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
