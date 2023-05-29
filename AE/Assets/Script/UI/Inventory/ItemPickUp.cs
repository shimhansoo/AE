using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private float range = 2.0f; // 거리

    public RaycastHit2D hitInfo; // 충돌체 정보

    public Inventory inventory; // 인벤토리에 저장
    
    [SerializeField]
    private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CheckItem();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform != null)
        {
            if (((layerMask & 1 << collision.gameObject.layer) != 0))
            {
                if (collision.transform.gameObject.GetComponent<Coin>())
                {
                    inventory.gold++;
                }
                else
                {
                    //Debug.Log(hitInfo.transform.gameObject);
                    GameObject acquiredItem = collision.transform.gameObject;
                    inventory.AcquireItem(acquiredItem); // 인벤토리에 아이템 추가
                }

                Destroy(collision.transform.gameObject);
            }
        }
    }

    public void CheckItem()
    {
        Vector2 hitpoint;
        if(transform.parent == null)
        {
            hitpoint = transform.position;
        }
        else
        {
            hitpoint = transform.parent.position;
        }
        hitpoint.x -= 0.1f;
        hitpoint.y += 0.1f;

        hitInfo = Physics2D.Raycast(hitpoint, new Vector2(1, 0), range, layerMask);
        Debug.DrawRay(hitpoint, new Vector2(1, 0), Color.magenta ,range);
        if(hitInfo.transform != null)
        {
            if(hitInfo.transform.gameObject.GetComponent<Coin>())
            {
                Debug.Log("골드 획득!");
                inventory.gold++;
            }
            else
            {
                Debug.Log(hitInfo.transform.gameObject);
                GameObject acquiredItem = hitInfo.transform.gameObject;
                inventory.AcquireItem(acquiredItem); // 인벤토리에 아이템 추가
            }
            
            Destroy(hitInfo.transform.gameObject);
        }
    }
}
