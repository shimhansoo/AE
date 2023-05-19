using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventroySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        // ��ӵ� ������ ���� ��������
        DragItem newitem = eventData.pointerDrag.GetComponent<DragItem>();
        DragItem curitem = GetComponentInChildren<DragItem>();

        //
        if (newitem != null)
        {
            
            if(curitem != null)
            {
                curitem.transform.SetParent(newitem.originalParent, true);
                curitem.transform.position = newitem.startPosition;
                Debug.Log("��ġ�̵���");
            }
            
            // �������� ��ӵ� �������� �̵���Ű��
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
