using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonsterMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //AirCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & targetMask) != 0)
            onTrace(collision);
        Debug.Log("Enter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        LostTarget(collision);
    }
}
