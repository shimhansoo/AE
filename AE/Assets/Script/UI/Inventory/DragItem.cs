using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    Vector2 dragOffset = Vector2.zero;

    public Transform orgParent
    {
        get; private set;
    }

    //장착
    public GameObject weaponSlot;
    public GameObject armorSlot;
    public GameObject soulSlot;

    public Transform a;
    public GameObject player;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragOffset = (Vector2)transform.position - eventData.position;
        orgParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        //GetComponent<Image>().raycastTarget = false;
        GetComponentInChildren<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(orgParent);
        transform.localPosition = Vector3.zero;
        GetComponentInChildren<Image>().raycastTarget = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + dragOffset;
    }
    public void ChangeParent(Transform p, bool update = false)
    {
        orgParent = p;
        if(update)
        {
            transform.SetParent(p);
            transform.localPosition = Vector3.zero;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Transform orgItem = transform.parent;
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(GetComponent<ItemPick>().item.itemType == Item.ItemType.Weapon)
            {
                if (weaponSlot.GetComponentInChildren<DragItem>() != null)
                {
                    a = weaponSlot.GetComponentInChildren<DragItem>().transform;
                    a.transform.SetParent(orgItem);
                    a.transform.localPosition = Vector3.zero;
                    OnChnage(a);
                }
                Debug.Log("Weapon");
                transform.SetParent(weaponSlot.transform);
                transform.localPosition = Vector3.zero;
                OnEquip(transform);
                
            }
            else if(GetComponent<ItemPick>().item.itemType == Item.ItemType.Armor)
            {
                if (armorSlot.GetComponentInChildren<DragItem>() != null)
                {
                    a = armorSlot.GetComponentInChildren<DragItem>().transform;
                    a.transform.SetParent(orgItem);
                    a.transform.localPosition = Vector3.zero;
                    OnChnage(a);
                }
                Debug.Log("Armor");
                transform.SetParent(armorSlot.transform);
                transform.localPosition = Vector3.zero;
                OnEquip(transform);
            }
            else if (GetComponent<ItemPick>().item.itemType == Item.ItemType.Soul)
            {
                if (soulSlot.GetComponentInChildren<DragItem>() != null)
                {
                    a = soulSlot.GetComponentInChildren<DragItem>().transform;
                    a.transform.SetParent(orgItem);
                    a.transform.localPosition = Vector3.zero;
                    OnChnage(a);
                }
                Debug.Log("Soul");
                transform.SetParent(soulSlot.transform);
                transform.localPosition = Vector3.zero;
                OnEquip(transform);
            }
        }
    }
    void Start()
    {
        weaponSlot = GameObject.Find("Weapon");
        armorSlot = GameObject.Find("Armor");
        soulSlot = GameObject.Find("Soul");
        if (GameObject.Find("Plyaer") != null)
        {
            player = GameObject.Find("Plyaer");
        }
        else if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChnage(Transform i)
    {
        Item item = i.GetComponent<ItemPick>().item;
        Debug.Log("공격력 : " + item.itemAttack + "스피드 : " + item.itemSpeed + "체력 : " + item.itemHP);
        player.GetComponent<CharacterProperty>().playerMaxHp -= item.itemHP;
        player.GetComponent<CharacterProperty>().playerMoveSpeed -= item.itemSpeed;
        player.GetComponent<CharacterProperty>().playerDamege -= item.itemAttack;
    }
    public void OnEquip(Transform i)
    {
        Item item = i.GetComponent<ItemPick>().item;
        Debug.Log("공격력 : " + item.itemAttack + "스피드 : " + item.itemSpeed + "체력 : " + item.itemHP);
        player.GetComponent<CharacterProperty>().playerMaxHp += item.itemHP;
        player.GetComponent<CharacterProperty>().playerMoveSpeed += item.itemSpeed;
        player.GetComponent<CharacterProperty>().playerDamege += item.itemAttack;
        PlayerLibrary pl = GameObject.Find("Player").GetComponent<PlayerLibrary>();
        if(item.itemType == Item.ItemType.Weapon)pl.ChangeToWP((int)item.weaponType);
    }
}
