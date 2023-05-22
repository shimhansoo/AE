using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public GameObject Item;
    public Image ItemImage;
    public bool isFull = false;
    public void AddItem(GameObject obj)
    {
        GameObject Item = Instantiate(obj, transform);
        Item.transform.SetParent(transform, true);
        Item.transform.localPosition = Vector3.zero;
        
        Rigidbody2D rigidbodyComponent = Item.GetComponent<Rigidbody2D>(); // 삭제할 RigidBody 컴포넌트 가져오기
        Destroy(rigidbodyComponent);
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
