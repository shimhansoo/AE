using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private float range = 2.0f; // �Ÿ�

    private bool pickupActivated = false; // ������ �Ծ���
    public RaycastHit2D hitInfo; // �浹ü ����

    public Inventory inventory; // �κ��丮�� ����
    
    [SerializeField]
    private LayerMask layerMask;

    public BaseSlot baseSlot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckItem();
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
        hitpoint.y -= 0.25f;

        hitInfo = Physics2D.Raycast(hitpoint, new Vector2(1, 0), range, layerMask);
        if(hitInfo.transform != null)
        {
            if(hitInfo.transform.gameObject.GetComponent<Coin>())
            {
                Debug.Log("��� ȹ��!");
                inventory.gold++;
            }
            else
            {
                inventory.AcquireItem(hitInfo.transform.GetComponent<ItemPick>().item);
            }
            
            Destroy(hitInfo.transform.gameObject);
        }
    }
    
}
