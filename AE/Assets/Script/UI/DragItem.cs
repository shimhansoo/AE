using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    Vector2 dragOffset = Vector2.zero;

    public Transform orgParent
    {
        get; private set;
    }
    public Image myIcon = null;
    public float coolTime = 3.0f;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragOffset = (Vector2)transform.position - eventData.position;
        orgParent = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        GetComponent<Image>().raycastTarget = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(orgParent);
        transform.localPosition = Vector2.zero;
        GetComponent<Image>().raycastTarget = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + dragOffset;
    }
    public void ChangeParent(Transform p, bool update = false)
    {
        orgParent = p;
        if(update)
        {
            transform.SetParent(p);
            transform.localPosition = Vector2.zero;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            if(Mathf.Approximately(myIcon.fillAmount, 1.0f))
            {
                myIcon.fillAmount = 1.0f;
                StopAllCoroutines();
                StartCoroutine(Cooling());
            }
        }
    }
    IEnumerator Cooling()
    {
        float Speed = 1.0f / coolTime;
        while(myIcon.fillAmount < 1.0f)
        {
            myIcon.fillAmount += Speed * Time.deltaTime;
            yield return null;
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
