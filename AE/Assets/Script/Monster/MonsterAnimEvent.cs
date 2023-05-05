using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterAnimEvent : MonoBehaviour
{
    public UnityEvent AttackFunc;
    public UnityEvent AutoAttackFunc;
    public UnityEvent DeadFunc;
    public void OnAttack()
    {
        AttackFunc?.Invoke();
    }
    public void OnAutoAttack()
    {
        AutoAttackFunc?.Invoke();
    }
    public void OnDead()
    {
        DeadFunc?.Invoke();
    }
}
