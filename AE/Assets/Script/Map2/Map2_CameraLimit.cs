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
