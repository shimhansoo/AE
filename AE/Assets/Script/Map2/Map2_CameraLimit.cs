using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2_CameraLimit : MonoBehaviour
{

    public GameObject target;
    public bool isLimit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(transform.position.y < 2)
        {
            transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
        }
        else if(transform.position.y > 23)
        {
            transform.position = new Vector3(transform.position.x, 23.0f, transform.position.z);
        }
        
        if(transform.position.x < -20)
        {
            transform.position = new Vector3(-20.0f, transform.position.y , transform.position.z);
        }
        else if(transform.position.x > 20)
        {
            transform.position = new Vector3(20.0f, transform.position.y, transform.position.z);
        }
        */
        if (isLimit == false)
        {
             target.transform.position = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLimit = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isLimit = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isLimit = false;
    }
}
