using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour , IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragItem newItem = eventData.pointerDrag.GetComponent<DragItem>();
        DragItem curItem = GetComponent<DragItem>();
        if(curItem != null )
        {
            curItem.ChangeParent(newItem.orgParent, true);
        }
        newItem.ChangeParent(transform);
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
