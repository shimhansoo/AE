using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Boss2AniEvent : MonoBehaviour
{
    public UnityEvent AttackFunc;
    public UnityEvent SmashFunc;
    public UnityEvent SkillFunc;
    public UnityEvent BreathFunc;
    public UnityEvent DeadFunc;
    public void OnAttack()
    {
        AttackFunc?.Invoke();
    }
    public void OnSmash()
    {
        SmashFunc?.Invoke();
    }
    public void OnSkill()
    {
        SkillFunc?.Invoke();
        
        
    }
    public void OnBreath()
    {
        BreathFunc?.Invoke();
    }    
    public void OnDead()
    {
        DeadFunc?.Invoke();
    }
    

}
