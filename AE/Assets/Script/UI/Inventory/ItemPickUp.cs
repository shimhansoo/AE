using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private float range = 2.0f; // �Ÿ�

    public RaycastHit2D hitInfo; // �浹ü ����

    public Inventory inventory; // �κ��丮�� ����
    
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
        Debug.Log(collision.transform.gameObject);
        if (collision.transform != null)
        {
            if (((layerMask & 1 << collision.gameObject.layer) != 0))
            {
                if (collision.transform.gameObject.GetComponent<Coin>())
                {
                    Debug.Log("��� ȹ��!");
                    inventory.gold++;
                }
                else
                {
                    //Debug.Log(hitInfo.transform.gameObject);
                    GameObject acquiredItem = collision.transform.gameObject;
                    inventory.AcquireItem(acquiredItem); // �κ��丮�� ������ �߰�
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
                Debug.Log("��� ȹ��!");
                inventory.gold++;
            }
            else
            {
                Debug.Log(hitInfo.transform.gameObject);
                GameObject acquiredItem = hitInfo.transform.gameObject;
                inventory.AcquireItem(acquiredItem); // �κ��丮�� ������ �߰�
            }
            
            Destroy(hitInfo.transform.gameObject);
        }
    }
}
