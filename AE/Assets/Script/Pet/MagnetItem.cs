using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;
using static UnityEngine.GraphicsBuffer;

public class MagnetItem : MonoBehaviour
{
    [SerializeField]
    private Vector2 PetPos;
    [SerializeField]
    private GameObject wolf;
    Transform itemObj;
    //List<Transform> items = new List<Transform>();
    Coroutine coMove = null;

    public LayerMask itemMask;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PetPos = wolf.transform.position;
        if(itemObj == null && coMove != null)
        {
            StopCoroutine(coMove);
            coMove = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if ((itemMask & 1 << collision.gameObject.layer) != 0)
        {
            itemObj = collision.transform;
            
            if(coMove == null) coMove = StartCoroutine(MoveItem(collision.transform));
        }
        
    }

    private IEnumerator MoveItem(Transform itemTransform)
    {
        Vector2 startPosition = itemTransform.position; // ���� ��ġ
        float journeyLength = Vector2.Distance(startPosition, PetPos); // �̵� �Ÿ�

        while (journeyLength > 0.01f) // �̵��� �Ϸ�� ������ �ݺ�
        {
            itemTransform.position = Vector2.Lerp(startPosition, PetPos, 0.5f * Time.deltaTime); // ������ ��ġ ����
            startPosition = itemTransform.position;
            journeyLength = Vector2.Distance(startPosition, PetPos);
            yield return null;
        }
    }
}
