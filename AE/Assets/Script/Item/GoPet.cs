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
    bool isGround = false;

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
        StartCoroutine(DisappearItem());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGround) return;
        if (pet == null) return;
        PetPos = pet.transform.position;
        dist = Vector2.Distance(transform.position, PetPos);
        
        if (dist <= range)
        {
            if(rigid != null)rigid.gravityScale = 0.1f;
            Physics2D.IgnoreLayerCollision(itemMask, GroundMask , true);
            transform.position = Vector2.Lerp(transform.position, PetPos, 1);
        }
        else
        {
            if (rigid != null) rigid.gravityScale = 1.0f;
            Physics2D.IgnoreLayerCollision(itemMask, GroundMask, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.layer << 1 & GroundMask) != 0)
        {
            isGround = true;
        }
    }
    IEnumerator DisappearItem()
    {
        float time = 0.0f;
        while (time < 10.0f) 
        {
            time += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }
}
