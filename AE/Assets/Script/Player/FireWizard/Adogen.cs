using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adogen : MonoBehaviour
{
    Vector2 dir = Vector2.zero;
    public SpriteRenderer ren = new SpriteRenderer();
    public Animator anim = new Animator();
    public LayerMask enemyMask;
    float destroyTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
        anim.SetTrigger("Skill2Attack");
    }
    private void Awake()
    {
        dir.x = transform.position.x - transform.parent.position.x;
        if (dir.x < 1) ren.flipX = true;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, 1f, enemyMask);
        if (enemy != null)
        {
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(100f);
            Destroy(gameObject);
        }

        destroyTime += Time.deltaTime;
        if (destroyTime > 10f)
        {
            Destroy(gameObject);
        }
    }
}
