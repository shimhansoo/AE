using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2_TestMove : MonoBehaviour
{
    public float Speed = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, Time.deltaTime * Speed, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0,-Time.deltaTime*Speed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Time.deltaTime * Speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Time.deltaTime * Speed, 0, 0);
        }
    }
}
