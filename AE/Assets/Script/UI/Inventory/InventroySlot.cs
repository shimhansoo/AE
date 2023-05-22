using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventroySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // 드롭된 아이템 정보 가져오기
        DragItem newitem = eventData.pointerDrag.GetComponent<DragItem>();
        DragItem curitem = GetComponentInChildren<DragItem>();

        if(curitem != null )
        {
            curitem.ChangeParent(newitem.orgParent, true);
        }
        newitem.ChangeParent(transform);
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
