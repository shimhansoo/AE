using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPet : MonoBehaviour
{
    [SerializeField]
    private Vector2 PetPos;
    public  GameObject pet;

    public LayerMask petMask;
    public float dist;
    [SerializeField]
    private float range = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        pet = GameObject.Find("WolfR");
    }

    // Update is called once per frame
    void Update()
    {
        if (pet == null) return;
        PetPos = pet.transform.position;
        dist = Vector2.Distance(transform.position, PetPos);
        
        if (dist <= range)
        {
            transform.position = Vector2.Lerp(transform.position, PetPos, Time.deltaTime);
        }
    }
}
