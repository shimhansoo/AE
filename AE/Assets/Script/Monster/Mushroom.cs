using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonsterProperty, GameManager.IBattle
{
    Transform myCreatePoint;
    [SerializeField]float createDelay = 5f;
    PolygonCollider2D myPolygonCollider2D;
    float tolerance = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        myPolygonCollider2D = GetComponent<PolygonCollider2D>();
        myCreatePoint = GetComponentInChildren<Transform>().Find("CreatePoint");
        TextArea = GetComponentInChildren<Transform>().Find("DMGTextArea");
        StartCoroutine(Creating());
    }

    // Update is called once per frame
    void Update()
    {
        SetCollider();
    }
    IEnumerator Creating()
    {
        float createTime = 0;
        while (true)
        {
            createTime += Time.deltaTime;
            if(createTime > createDelay)
            {
                myAnim.SetTrigger("Attack");
                createTime = 0;
            }
            yield return null;
        }
    }
    public void CreateFungal()
    {
        Instantiate(Resources.Load("Monster/Fungal"), myCreatePoint.position, Quaternion.identity);
    }

    // Interface IBattle //
    public bool isLive
    {
        get => myState != State.Death;
    }
    public void OnTakeDamage(float dmg)
    {
        GameObject obj = Instantiate(Resources.Load("UI/DmgText"), TextArea) as GameObject;
        obj.GetComponent<DamageText>().ChangeTextColor(dmg);
        curHp -= dmg;
        if (dmg < 0)
        {
            myAnim.SetTrigger("OnHealColor");
            return;
        }
        myAnim.SetTrigger("OnDamageColor"); // 피격시 이미지의 색상을 바꿔주도록 Animator에서 설정

        if (!Mathf.Approximately(curHp, 0f))
        {
            if (!myAnim.GetBool("isAttacking"))
                myAnim.SetTrigger("OnDamage");  // 공격중엔 애니메이션 호출 안 함
        }
        else
        {
            Collider2D[] colList = transform.GetComponentsInChildren<Collider2D>();
            foreach (Collider2D col in colList) col.enabled = false;
            StopAllCoroutines();
            StartCoroutine(Death());
        }
    }
    // Interface IBattle //
    IEnumerator Death()
    {
        myAnim.SetTrigger("Death");
        yield return StartCoroutine(DroppingItem());
        yield return new WaitUntil(() => myAnim.GetBool("Done"));
        Destroy(gameObject);
    }
    WaitForSeconds waitCoinPop = new WaitForSeconds(0.05f);
    IEnumerator DroppingItem()
    {
        Vector2 orgPos = transform.position;
        int coinNum = Random.Range(1, 21);
        for (int i = 0; i < coinNum; i++)
        {
            yield return waitCoinPop;
            GameObject coinObj = Instantiate(Resources.Load("Item/Coin"), orgPos, Quaternion.identity) as GameObject;
            coinObj.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 5f)), ForceMode2D.Impulse);
        }
    }
    void SetCollider()
    {
        List<Vector2> points = new List<Vector2>();
        List<Vector2> simplifiedPoints = new List<Vector2>();
        myPolygonCollider2D.pathCount = myRenderer.sprite.GetPhysicsShapeCount();
        for (int i = 0; i < myPolygonCollider2D.pathCount; i++)
        {
            myRenderer.sprite.GetPhysicsShape(i, points);
            LineUtility.Simplify(points, tolerance, simplifiedPoints);
            myPolygonCollider2D.SetPath(i, simplifiedPoints);
        }
    }
}
