using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TotemDebuffIcon : Totem, ITotem
{
    float slowTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y + 1f);
        transform.parent.GetComponent<Player>().playerMoveSpeed *= ((100 - SlowPercentage) * 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        slowTime -= Time.deltaTime;
        //Debug.Log(slowTime);
    }

    public void SetDebuffTime(float time)
    {
        slowTime = time;
    }
    public void EndDebuff()
    {
        if (slowTime < 0.0f)
        {
            myTarget.GetComponent<Player>().playerMoveSpeed = tmpMoveSpeed;
            Destroy(gameObject);
        }
    }
}
