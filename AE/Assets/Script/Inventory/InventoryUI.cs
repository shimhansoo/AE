using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    bool activeIventory = false;


    void Start()
    {
        inventoryPanel.SetActive(activeIventory);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeIventory = !activeIventory;
            inventoryPanel.SetActive(activeIventory);
        }
    }
}
