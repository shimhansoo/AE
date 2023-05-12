using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfItemPerception : PetProperty
{
    public List<GameObject> ItemList = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*ItemList.Add(collision.gameObject);*/
        if ((ItemMask & 1 << collision.gameObject.layer) != 0)
        {
            ItemList.Add(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
