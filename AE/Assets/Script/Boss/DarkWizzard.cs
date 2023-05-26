using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkWizzard : MonoBehaviour
{
    public Transform target;
    public SpriteRenderer rend;
    public float test = 0.5f;
    public Transform left;
    public Transform right;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attacking());
        StartCoroutine(coTelePort());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            target = GameObject.Find("Player").transform;
        }
        else if (GameObject.Find("Plyaer") != null)
        {
            target = GameObject.Find("Plyaer").transform;
        }

        rend = GetComponent<SpriteRenderer>();
        //Debug.Log(target.position.x - transform.parent.position.x);
        if (target.position.x - transform.parent.position.x > 0)
        {
            rend.flipX = false;
        }
        else if(target.position.x - transform.parent.position.x < 0)
        {
            rend.flipX = true;
        }
    }
    IEnumerator Attacking()
    {
        while(true)
        {
            Animator animator = transform.GetComponent<Animator>();
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(2.0f);
        }
    }
    public void Attack()
    {
        if (rend.flipX)
        {
            Vector2 orgPos = left.position;
            //orgPos.y += 0.5f;
            //orgPos.x += 2.0f;
            GameObject obj = Instantiate(Resources.Load("Monster/DarkWizzardBall/DarkWizzardBall"), orgPos, Quaternion.identity) as GameObject;
        }
        else
        {
            Vector2 orgPos = right.position;
            //orgPos.y += 0.5f;
            //orgPos.x += 2.0f;
            GameObject obj = Instantiate(Resources.Load("Monster/DarkWizzardBall/DarkWizzardBall"), orgPos, Quaternion.identity) as GameObject;
        }
        
    }
    IEnumerator coTelePort()
    {
        while(true)
        {
            Animator animator = transform.GetComponent <Animator>();
            animator.SetTrigger("Teleport");
            yield return new WaitForSeconds(5.0f);
        }
    }
    public void TelePort()
    {
        Vector2 des = target.position;
        des.y -= test;
        transform.parent.position = des;
    }
}
