using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupController : MonoBehaviour
{
    [SerializeField]
    private float range = 2.0f; // °Å¸®
    
    private bool pickupActivated = false; // °¡±î¿ì¸é ¸Ô¾îÁü
    private RaycastHit2D hitInfo; // Ãæµ¹Ã¼ Á¤º¸

    [SerializeField]
    private LayerMask layerMask; 

    [SerializeField]
    private Text actionText;

    [SerializeField]
    private Inventory theInventory;



    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        //CheckItem();
        TryAction();
    }
    private void TryAction()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }
    private void CheckItem()
    {
        //hitInfo = Physics2D.Raycast(transform.position, transform.right, range);
        Vector2 hitPoint;
        if(transform.parent == null)
            hitPoint = transform.position;
        else
            hitPoint = transform.parent.position;


        hitPoint.y -= 0.25f;
        hitInfo = Physics2D.Raycast(hitPoint, new Vector2(1,0), range, layerMask);
        Debug.DrawRay(hitPoint, new Vector2(1, 0), Color.gray, range);
        if (hitInfo)
        {
            Debug.Log(hitInfo);
            print(hitInfo.collider.gameObject.layer);
            if(hitInfo.transform.CompareTag("Item")) 
            {
                ItemInfoAppear();
            }
            else
            {
                ItemInfoDisappear();
            }
        }
        else
        {
            hitInfo = Physics2D.Raycast(hitPoint, new Vector2(-1, 0), range, layerMask);
            Debug.DrawRay(hitPoint, new Vector2(-1, 0), Color.gray, range);

            if (hitInfo)
            {
                Debug.Log(hitInfo);
                if(hitInfo.transform.CompareTag("Item")) 
                {
                    ItemInfoAppear();
                }
                else
                {
                    ItemInfoDisappear();
                }
            }
        }
    }
    private void ItemInfoAppear()
    {
        pickupActivated = true;
        //actionText.gameObject.SetActive(true);
        //actionText.text = hitInfo.transform.GetComponent<ItemPickup>().item.itemName + " È¹µæ " + "<color=yellow>" + "(E)" + "</color>";
    }
    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        //actionText.gameObject.SetActive(false);
    }
    private void CanPickUp()
    {
        if(pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickup>().item.itemName + " È¹µæ."); // ÀÎº¥ ³Ö±â
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickup>().item);
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
