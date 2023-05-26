using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizzardBall : MonoBehaviour
{
    public Transform target;
    SpriteRenderer rend;
    public float Speed = 1.0f;
    public LayerMask monsterMask;
    public LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        playerMask.value = 6;
        monsterMask.value = 7;
        if(GameObject.Find("Player") != null)
        {
            target = GameObject.Find("Player").transform;
        }
        else if(GameObject.Find("Plyaer") != null)
        {
            target = GameObject.Find("Plyaer").transform;
        }
        rend = GetComponent<SpriteRenderer>();
        if(target.position.x > transform.position.x)
        {
            rend.flipX = true;
        }
        else
        {
            rend.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rend.flipX == true)transform.Translate(Vector2.right * Speed * Time.deltaTime);
        else if (rend.flipX == false) transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!(monsterMask.value == collision.gameObject.layer))
        {
            Explosion();
            if(playerMask.value == collision.gameObject.layer)
            {
                target.GetComponent<CharacterProperty>().playerCurHp -= 10.0f;
            }
        }
        
    }
    public void Explosion()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("Explode");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
    
}
