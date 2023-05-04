using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossAniEvent : MonoBehaviour
{
    public UnityEvent AttackFunc;
    public UnityEvent SwingFunc;
    public UnityEvent EarthFunc;
    public UnityEvent DeadFunc;
    void OnAttack()
    {
        AttackFunc?.Invoke();
    }
    void OnSwing()
    {
        SwingFunc?.Invoke();
    }
    void OnEarth()
    {
        EarthFunc?.Invoke();
       
    }
    public void OnDead()
    {
        DeadFunc?.Invoke();
    }
}
