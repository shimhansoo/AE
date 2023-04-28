using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireSpritSkill : MonoBehaviour
{
    public Transform Target;
    public Transform DRG;

    public UnityEvent Reset = null;

    public float ThrowSpeed = 10.0f;
    public int Count = 0;
    public int CountCount = 0;
    public float StartXPos = 1.0f;
    public float StartYPos = 1.0f;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject TargetPos = GameObject.Find("OrcWarrior");
        Target = TargetPos.transform;
        GameObject DRGPos = GameObject.Find("FireDragon(Clone)");
        DRG = DRGPos.transform;
    }
    void Start()
    {
        transform.position = DRG.position + new Vector3(StartXPos, StartYPos, 0);
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ++Count;
            if (Count == 4)
            {
                Reset?.Invoke();
            }
        }
        if(Count == CountCount)
        {
            StopAllCoroutines();
            StartCoroutine(ThrowSkill());            
        }
    }
    IEnumerator ThrowSkill()
    {
        Vector2 dir = Target.position - transform.position;
        float delta = ThrowSpeed * Time.deltaTime;        
        while (true)
        {
            transform.Translate(dir * delta);
            if (Mathf.Abs(dir.x ) < 0.5f)
            {
                Destroy(gameObject);
            }
            yield return null;
        }
        
    }
}
