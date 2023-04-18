using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Transform player;
    public float speed;
    public Vector2 home;

    public float atkCooltime = 4;
    public float atkDelay;
    public float skillCooltime = 10;
    public float skillDelay;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        home = transform.position;
    }
    private void Update()
    {
        if (atkDelay >= 0)
            atkDelay -= Time.deltaTime;
        if (skillDelay >= 0)
            skillDelay -= Time.deltaTime;
    }
    // Update is called once per frame
    public void DirectionEnemy(float target, float baseobj)
    {
        if (target < baseobj)
            animator.SetFloat("Direction", -1);
        else
            animator.SetFloat("Direction", 1);
    }
}
