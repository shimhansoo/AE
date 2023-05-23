using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;
    public UnityEvent OnAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LongAttacking()
    {
        GameObject temp = Instantiate(Resources.Load("Player/Firebolt"), attackPoint.position, Quaternion.identity) as GameObject;
        temp.transform.SetParent(gameObject.transform);
    }
    void Attacking()
    {
        OnAttack?.Invoke();
    }
}
