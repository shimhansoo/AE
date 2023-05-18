using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Item item;
    public Image itemImage;

    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        // 임시 추가
        //transform.AddComponent<Image>();
        //itemImage = transform.GetComponent<Image>();
        // 원본
        itemImage.sprite = item.itemImage;


        Debug.Log("도착");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
