using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TotemDebuffIcon : Totem
{
    public static TotemDebuffIcon Inst = null;
    float buffTime = 5.0f;
    float slowSpeed = 0f;
    float tmpAdditionalSpeed = 0f;
    private void Awake()
    {
        Inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y + 1f);
        tmpAdditionalSpeed = transform.parent.GetComponent<Player>().additionalSpeed;

        slowSpeed = transform.parent.GetComponent<Player>().playerMoveSpeed * (SlowPercentage * 0.01f);
        transform.parent.GetComponent<Player>().additionalSpeed = -slowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        buffTime -= Time.deltaTime;
        Debug.Log(buffTime);
        CheckTime();
    }

    public void SetBuffTime(float time)
    {
        buffTime = time;
    }
    public void CheckTime()
    {
        if(buffTime < 0.0f)
        {
            transform.parent.GetComponent<Player>().additionalSpeed = tmpAdditionalSpeed;
            //totem.isSlow = false;
            Destroy(gameObject);
        }
    }
}
