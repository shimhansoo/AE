using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class FireBlast : MonoBehaviour
{
    //Polygon 관련
    PolygonCollider2D myPolygonCollider2D;
    SpriteRenderer myRenderer;
    //CoolTime관련
    float coolTime = 1.0f;
    float destroyTime = 0f;
    //Attack관련
    public LayerMask enemyMask;
    float front = 0;
    Collider2D[] enemyLists = null;
    Vector2 capsuleSize = Vector2.zero;
    float s = 0;
    private void Start()
    {
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);//부모 스케일 따라와서 고정스케일 잡아줌
    }

    void Awake()
    {
        myPolygonCollider2D = GetComponent<PolygonCollider2D>();
        myRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PolygonCheck();
        EnemyAttack();

        coolTime += Time.deltaTime;
        destroyTime += Time.deltaTime;
        if (destroyTime >= 5.0f)
        {
            Destroy(gameObject);
        }
    }

    void PolygonCheck()
    {
        List<Vector2> points = new List<Vector2>();
        List<Vector2> simplifiedPoints = new List<Vector2>();
        myPolygonCollider2D.pathCount = myRenderer.sprite.GetPhysicsShapeCount();
        for (int i = 0; i < myPolygonCollider2D.pathCount; i++)
        {
            myRenderer.sprite.GetPhysicsShape(i, points);
            LineUtility.Simplify(points, 0.1f, simplifiedPoints);
            myPolygonCollider2D.SetPath(i, simplifiedPoints);
        }
    }

    void EnemyAttack()
    {
        if (transform.parent.localScale.x < 0) front = -myPolygonCollider2D.bounds.extents.x;//방향값 구하기 위함
        else front = myPolygonCollider2D.bounds.extents.x;
        capsuleSize.x = myPolygonCollider2D.bounds.extents.x * 3f;
        capsuleSize.y = myPolygonCollider2D.bounds.extents.y * 2;
        enemyLists = Physics2D.OverlapCapsuleAll(new Vector2(transform.position.x + front, transform.position.y), capsuleSize, CapsuleDirection2D.Horizontal, 0, enemyMask);
        if (coolTime >= 1.0f)
        {
            foreach (Collider2D col in enemyLists)
            {
                s = Random.Range(1f, 2.5f);
                col.GetComponent<GameManager.IBattle>().OnTakeDamage((int)(25f*s));
            }
            coolTime = 0.0f;
        }
    }
}
