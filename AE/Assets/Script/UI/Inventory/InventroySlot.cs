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

        //
        if (newitem != null)
        {
            
            if(curitem != null)
            {
                curitem.transform.SetParent(newitem.originalParent, true);
                curitem.transform.position = newitem.startPosition;
                Debug.Log("위치이동ㅋ");
            }
            
            // 아이템을 드롭된 슬롯으로 이동시키기
            newitem.transform.SetParent(transform);
            newitem.transform.position = transform.position;
        }
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
