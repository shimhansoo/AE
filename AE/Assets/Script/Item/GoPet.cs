using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPet : MonoBehaviour
{
    [SerializeField]
    private Vector2 PetPos;
    public  GameObject pet;
    public float dist;
    [SerializeField]
    private float range = 10.0f;

    // ²ø·Á¿Ã
    public LayerMask itemMask;
    public LayerMask GroundMask;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        pet = GameObject.Find("WolfR");
        rigid = GetComponent<Rigidbody2D>();
        itemMask = LayerMask.NameToLayer("Item");
        GroundMask = LayerMask.NameToLayer("Ground");

        Debug.Log(itemMask);
        Debug.Log(GroundMask);
    }

    // Update is called once per frame
    void Update()
    {
        if (pet == null) return;
        PetPos = pet.transform.position;
        dist = Vector2.Distance(transform.position, PetPos);
        
        if (dist <= range)
        {
            if(rigid != null)rigid.gravityScale = 0.1f;
            Physics2D.IgnoreLayerCollision(itemMask, GroundMask , true);
            transform.position = Vector2.Lerp(transform.position, PetPos, Time.deltaTime);
        }
        else
        {
            if (rigid != null) rigid.gravityScale = 1.0f;
            Physics2D.IgnoreLayerCollision(itemMask, GroundMask, false);
        }
    }
}
