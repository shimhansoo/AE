using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterAttack : MonsterMovement
{
    public UnityEvent _Attack;

    public void OnAttack()
    {
        _Attack?.Invoke();
    }
}
