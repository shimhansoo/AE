using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPerception : MonoBehaviour
{
    public Transform Target = null;
    public enum State
    {
        Creat, Normal, Battle
    }
    State PetState = State.Creat;

    void ChangeState(State s)
    {
        PetState = s;
        switch (PetState)
        {
            case State.Normal:
                break;
            case State.Battle:
                break;
            default:
                break;        
        }
    }
    void StateProces(State s)
    {
        switch (PetState)
        {
            case State.Normal:
                break;
            case State.Battle:
                break;
            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
