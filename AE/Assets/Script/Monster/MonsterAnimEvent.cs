using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterAnimEvent : MonoBehaviour
{
    public UnityEvent AttackFunc;
    public UnityEvent DeadFunc;
    void OnAttack()
    {
        AttackFunc?.Invoke();
    }
    public void OnDead()
    {
        DeadFunc?.Invoke();
    }
}
