using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushromSkill : MonsterProperty
{
    public enum Type
    {
        Skill,None
    }
    public Type myType = Type.None;
    public LayerMask crashMask;
    public float DropSpeed = 0.0f;
    public Sprite[] imgList;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetType(Type type)
    {
        myType = type;
        myRenderer.sprite = imgList[(int)myType];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * DropSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(((1 << collision.gameObject.layer)& crashMask)!=0)
        {
            Destroy(gameObject);
        }
    }
}
