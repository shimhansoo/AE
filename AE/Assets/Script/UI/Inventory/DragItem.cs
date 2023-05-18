using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform originalParent;
    public Vector2 startPosition;
    Vector2 dragOffset = Vector2.zero;
    public Transform drag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 시 원래의 부모와 위치 저장
        originalParent = transform.parent;
        startPosition = transform.position;
        // 드래그 시작 시 RaycastTarget False
        GetComponent<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // 만약 드롭된 슬롯이 없는 경우, 아이템을 원래의 위치로 되돌립니다.
        if (transform.parent == originalParent || transform.parent == drag)
        {
            transform.position = startPosition;
            transform.parent = originalParent;
        }
        // 드래그 종료 시 RaycastTarget True
        GetComponent<Image>().raycastTarget = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(drag);
        // 드래그된 아이템을 최상위 레이어로 올리기
        transform.SetAsLastSibling();
        // 드래그 중인 아이템을 마우스 위치로 이동시키기
        transform.position = Input.mousePosition;
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
