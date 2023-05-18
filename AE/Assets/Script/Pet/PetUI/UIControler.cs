using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControler : MonoBehaviour
{
    public GameObject Tuobj = null;
    public float CoolTime = 3.0f;
    float curTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Tuobj.activeSelf)
        {
            curTime += Time.deltaTime;
            if (curTime >= CoolTime)
            {
                Destroy(gameObject);
            }
        }
    }
}
