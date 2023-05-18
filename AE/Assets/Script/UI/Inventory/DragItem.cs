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
        // �巡�� ���� �� ������ �θ�� ��ġ ����
        originalParent = transform.parent;
        startPosition = transform.position;
        // �巡�� ���� �� RaycastTarget False
        GetComponent<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // ���� ��ӵ� ������ ���� ���, �������� ������ ��ġ�� �ǵ����ϴ�.
        if (transform.parent == originalParent || transform.parent == drag)
        {
            transform.position = startPosition;
            transform.parent = originalParent;
        }
        // �巡�� ���� �� RaycastTarget True
        GetComponent<Image>().raycastTarget = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(drag);
        // �巡�׵� �������� �ֻ��� ���̾�� �ø���
        transform.SetAsLastSibling();
        // �巡�� ���� �������� ���콺 ��ġ�� �̵���Ű��
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
