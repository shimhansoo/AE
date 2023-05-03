using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearAttack : BattleSystem
{
    Transform pos = null;
    Vector2 spearDir = Vector2.zero;
    float spearAttackTime = 0f;
    float spearAttackRange = 1.0f;
    public GameObject spearEffect;
    void Start()
    {
        transform.Rotate(0, 0, -90.0f);
        StartCoroutine(spearWeaponDestroy());
    }

    private void Awake()
    {
        GameObject attackPos = GameObject.Find("AttackPoint");
        pos = attackPos.transform;
        spearDir.y = transform.position.x - pos.transform.position.x > 0 ? -1 : 1;
        if (!Mathf.Approximately(spearDir.y, 0.0f))
        {
            transform.localScale = spearDir.y < 0.0f ? new Vector3(1, -1, 1) : new Vector3(1, 1, 1);
        }
    }
    void Update()
    {
        transform.Translate(spearDir * 2.0f * Time.deltaTime);
        spearAttackTime += Time.deltaTime;
        if (spearAttackTime >= 0.3f)//0.3�ʸ��� ����
        {
            spearAttackTime = 0f;
            spearAttack();
        }
    }
    IEnumerator spearWeaponDestroy()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
    void spearAttack()
    {
        Collider2D[] Enemys = Physics2D.OverlapCircleAll(attackPoint.transform.position, spearAttackRange, enemyLayers);
        foreach (Collider2D enemy in Enemys)
        {
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(15.0f);
            Instantiate(spearEffect, new Vector2(enemy.transform.position.x, enemy.transform.position.y+0.3f), Quaternion.identity);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(attackPoint.transform.position, spearAttackRange);
    }
}
