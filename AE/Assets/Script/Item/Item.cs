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

    public string itemName; // �̸�

    public ItemGrade itemGrade; // ������ ���
    public ItemType itemType; // ���� �� �ҿ�
    public WPTYPE weaponType;
    public float itemHP = 0; // �߰� ü��
    public float itemAttack = 0; // �߰� ���ݷ�
    public float itemSpeed = 0; // �߰� �̼� ��



    public Sprite itemImage; // �κ��丮���� �� ������ �̹���
    public GameObject itemPrefab; // ������

    //public string weaponType; // ����
}
