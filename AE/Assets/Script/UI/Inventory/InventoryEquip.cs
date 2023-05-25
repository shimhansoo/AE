using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEquip : MonoBehaviour
{
    public GameObject player;
    public GameObject weaponSlot;
    public GameObject armorSlot;
    public GameObject soulSlot;
    // Start is called before the first frame update
    void Start()
    {
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
    
}
