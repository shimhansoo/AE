using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D), (typeof(CircleCollider2D)))]

public class Dropfire : Boss2Property
{
    public UnityEvent OnHitFunc;
    public Boss2 myParent = null;
   

    private List<GameObject> gameobject = new List<GameObject>();


    private void Awake()
    {
        myParent = GetComponentInParent<Boss2>();
    }
    // Start is called before the first frame update
   
    void Start()
    {
       
        StartCoroutine(Moving());
        /*this.attackDamage = myParent.SkillDamage;*/
        transform.SetParent(null);
      
       
    }
   

    IEnumerator Moving()
    {
        float playTime = 0.0f;
        Vector2 dir = myParent.attackTarget.position - transform.position;
        dir.Normalize();
       

        while (true)
        {
            playTime += Time.deltaTime;
            if (playTime > 3f) Destroy(gameObject);
            transform.Translate(dir * MoveSpeed * Time.deltaTime, Space.World);

            yield return null;
        }
    }
    public void DropRandom(Animator animator)
    {
        StartCoroutine(FireRain(animator));
    }
    IEnumerator FireRain(Animator animator)
    {
        int Count = Random.Range(1, 6);
        while (Count >= 0)
        {
            float timer = Random.Range(1.0f, 3.0f);
            Count--;
            GameObject obj1 = Instantiate(Resources.Load("BossMonsters/Fire") as GameObject);
            obj1.transform.position = new Vector2(animator.transform.position.x + (Random.Range(-5f, 5f)), animator.transform.position.y + 5f);
            yield return new WaitForSeconds(timer);
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

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


