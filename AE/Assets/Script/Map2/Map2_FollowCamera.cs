using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2_FollowCamera : MonoBehaviour
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
        if(isLimit == false)
        {
            transform.position = target.transform.position;
        }
    }
}
