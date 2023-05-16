using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public Item item;
    public int itemCount;
    public Image itemImage;

    //private WeaponManager theWeaponManager;

    [SerializeField]
    private TMP_Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;
    [SerializeField]
    protected Graphic _raycastTarget;
    
    // �̹��� ����
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
    // �κ��丮�� ���� �߰�
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;
        
        if(item.itemType == Item.ItemType.Weapone)
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        else if (item.itemType == Item.ItemType.Weapone)
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        else if (item.itemType == Item.ItemType.Weapone)
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }
        else
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }

        SetColor(1);
    }
    // �ش� ������ ������ ���� ������Ʈ
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if(itemCount <= 0 )
        {
            ClearSlot();
        }
    }
    // ���� ����
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }



    // Start is called before the first frame update
    void Start()
    {
        //theWeaponManager = FindObjectOfType<WeaponManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            // ����
            //StartCoroutine(theWeaponManager.ChangeWeaponCoroutine(item.weaponeType, item.itemName));
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       
        DragSlot.instance.SetColor(0);
        DragSlot.instance.dragSlot = null;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(DragSlot.instance.dragSlot != null)
        {
            ChangeSlot();
        }
    }
    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        /*
        if(_tempItemCount != null)
        {
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }
        */
        DragSlot.instance.dragSlot.ClearSlot();
    }
}
