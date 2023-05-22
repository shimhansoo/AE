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
    //[SerializeField]
    //private GameObject go_SlotsParent;

    
    public Slots[] slot;
    // Start is called before the first frame update
    void Start()
    {
        //slot = go_SlotsParent.GetComponentsInChildren<Slots>();
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
        for(int i = 0; i < slot.Length; i++)
        {
            if(slot[i].GetComponentInChildren<DragItem>())
            {
                slot[i].isFull = true;
            }
            else
            {
                slot[i].isFull = false;
            }
        }
    }
    public void CloseBtn()
    {
        Inven.SetActive(false);
        isInven = false;
    }
    public void AcquireItem(GameObject obj)
    {
        
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].isFull == false)
            {
                slot[i].AddItem(obj);
                return;
            }
        }
    }
}
