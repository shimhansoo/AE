using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShamanTotem : MonsterProperty
{
    GameObject obj = null;
    Transform targetPlayer = null;
    public Transform ShamanIamage = null;
    public int SlowPercentage = 100;
    private float tmpMoveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.GetComponentInChildren<SpriteRenderer>().flipX = true ? myRenderer.flipX = true : myRenderer.flipX = false;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //if(obj != null)
        //{
        //    obj.transform.position = new Vector2(myTarget.transform.position.x, myTarget.transform.position.y + 1f);
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (obj != null) return;
        if ((targetMask & 1 << collision.gameObject.layer) != 0)
        {
            obj = Instantiate(Resources.Load("Monster/Totem_DeBuff"), collision.transform) as GameObject;
            obj.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 1.5f);
            targetPlayer = collision.transform;
            tmpMoveSpeed = targetPlayer.GetComponent<Player>().playerMoveSpeed;
            targetPlayer.GetComponent<Player>().playerMoveSpeed *= ((100 - SlowPercentage) * 0.01f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(obj != null) Destroy(obj);
        targetPlayer.GetComponent<Player>().playerMoveSpeed = tmpMoveSpeed;
    }
}
