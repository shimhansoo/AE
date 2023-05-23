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

    public LayerMask itemMask;

    // Start is called before the first frame update
    void Start()
    {
        wolf = GameObject.Find("Wolf");
    }

    // Update is called once per frame
    void Update()
    {
        PetPos = wolf.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((itemMask & 1 << collision.gameObject.layer) != 0)
        {
            print(collision.transform);
            StartCoroutine(MoveItem(collision.transform));
        }
        
    }
    private IEnumerator MoveItem(Transform itemTransform)
    {
        Vector2 startPosition = itemTransform.position; // ���� ��ġ
        float journeyLength = Vector2.Distance(startPosition, PetPos); // �̵� �Ÿ�
        itemTransform.GetComponent<Rigidbody2D>().simulated = false;

        while (journeyLength > 0.01f) // �̵��� �Ϸ�� ������ �ݺ�
        {
            itemTransform.position = Vector2.Lerp(startPosition, PetPos, 0.5f * Time.deltaTime); // ������ ��ġ ����
            startPosition = itemTransform.position;
            journeyLength = Vector2.Distance(startPosition, PetPos);
            yield return null;
        }
        Debug.Log("����");
    }
}
