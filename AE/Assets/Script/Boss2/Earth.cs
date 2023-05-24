using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), (typeof(CircleCollider2D)))]
public class Earth : BossProperty
{
    public UnityEvent OnHitFunc;
    public BossMonster myParent = null;

    private void Awake()
    {
        myParent = GetComponentInParent<BossMonster>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Damage());
        //this.EarthDamage = myParent.EarthDamage;
        transform.SetParent(null);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & groundMask) != 0) return;
        StopAllCoroutines();
        myAnim.SetTrigger("OnHit");
        if ((1 << collision.gameObject.layer & targetMask) != 0)
        {
            collision.transform.GetComponent<GameManager.IBattle>().OnTakeDamage(EarthDamage);
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
