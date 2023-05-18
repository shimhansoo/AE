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

    public string itemName; // 이름
    public ItemType itemType; // 무기 방어구 소울
    public Sprite itemImage; // 인벤토리에서 쓸 아이템 이미지
    public GameObject itemPrefab; // 프리팹

    public string weaponType; // 유형
}
