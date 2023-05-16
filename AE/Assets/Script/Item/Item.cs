using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Weapone,
        Armor,
        Soul
    }
    public string itemName; // �̸�
    public ItemType itemType; // ����
    public Sprite itemImage; // �κ��丮 �̹��� 
    public GameObject itemPrefab; // ������

    public string weaponeType; // ���� ����
}
