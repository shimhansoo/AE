using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Weapon, Armor, Soul
    }
    public enum ItemGrade
    {
        Normal, Rare, Unique
    }
    public enum WPTYPE
    {
        None, Sword = 0, Staff, Spear
    }

    public string itemName; // 이름

    public ItemGrade itemGrade; // 아이템 등급
    public ItemType itemType; // 무기 방어구 소울
    public WPTYPE weaponType;
    public float itemHP = 0; // 추가 체력
    public float itemAttack = 0; // 추가 공격력
    public float itemSpeed = 0; // 추가 이속 ㅋ



    public Sprite itemImage; // 인벤토리에서 쓸 아이템 이미지
    public GameObject itemPrefab; // 프리팹

    //public string weaponType; // 유형
}
