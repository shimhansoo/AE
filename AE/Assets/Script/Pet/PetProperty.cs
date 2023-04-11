using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetProperty : MonoBehaviour
{
    public float PetSpeed = 1.0f;
    public float PetJump = 3.0f;
    public Transform player = null;
    Animator _PetAnim;
    SpriteRenderer _PetRenderer;

    protected Animator PetAnim
    {
        get
        {
            if (_PetAnim == null)
            {
                _PetAnim = GetComponent<Animator>();
                if (_PetAnim == null)
                {
                    _PetAnim = GetComponentInChildren<Animator>();
                }
            }
            return _PetAnim;
        }
    }
    protected SpriteRenderer PetRenderer
    {
        get
        {
            if (_PetRenderer == null)
            {
                _PetRenderer = GetComponent<SpriteRenderer>();
                if (_PetRenderer == null)
                {
                    _PetRenderer = GetComponentInChildren<SpriteRenderer>();
                }
            }
            return _PetRenderer;
        }
    }
}
