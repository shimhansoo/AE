using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebolt : CharacterProperty
{
    Vector2 pos = Vector2.zero;
    float fireboltAttackSpeed = 5.0f;
    RaycastHit2D hitGround = new RaycastHit2D();
    void Start()
    {
        pos.x = transform.position.x - transform.parent.position.x > 0 ? 1 : -1;
        if(pos.x == -1)  myRenderer.flipX = true;
        transform.SetParent(null);
        StartCoroutine(Destroy());
    }
    void Update()
    {
        transform.Translate(pos * fireboltAttackSpeed * Time.deltaTime);
        Collider2D enemy = Physics2D.OverlapCircle(transform.position, 0.5f, enemyLayers);
        playerDamege = Random.Range(20, 30);
        if (enemy != null)
        {
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(playerDamege);
            Destroy(gameObject);
        }
        hitGround = Physics2D.Raycast(transform.position, pos, 0.3f, groundMask);
        if(hitGround.collider != null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
