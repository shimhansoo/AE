using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int gold;
    public GameObject Inven;
    public bool isInven = false;
    [SerializeField]
    private GameObject go_SlotsParent;

    [SerializeField]
    private Slots[] slot;
    // Start is called before the first frame update
    void Start()
    {
        slot = go_SlotsParent.GetComponentsInChildren<Slots>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(!isInven)
            {
                Inven.SetActive(true);
                isInven = true;
            }
            else
            {
                Inven.SetActive(false);
                isInven = false;
            }
        }

    }
    public void CloseBtn()
    {
        Inven.SetActive(false);
        isInven = false;
    }
    /*
    public void AddItem(Sprite t)
    {
        Debug.Log(t);
    }
    */
    public void AcquireItem(Item _item, int _count = 1)
    {
        for(int i = 0; i < slot.Length; i++)
        {
            if (slot[i].item == null)
            {
                slot[i].AddItem(_item, _count);
                return;
            }
        }
    }
}
