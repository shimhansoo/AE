using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShamanTotem : MonsterProperty
{
    GameObject obj = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Totem");
    }

    // Update is called once per frame
    void Update()
    {
        if(obj != null)
        {
            obj.transform.position = new Vector2(myTarget.transform.position.x, myTarget.transform.position.y + 1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (obj != null) return;
        if ((targetMask & 1 << collision.gameObject.layer) != 0)
        {
            obj = Instantiate(Resources.Load("Monster/Totem_DeBuff")) as GameObject;
            obj.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + 1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(obj != null) Destroy(obj);
    }
}
