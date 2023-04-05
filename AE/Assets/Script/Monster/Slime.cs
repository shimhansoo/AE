using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonsterMovement
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTrace(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        LostTarget(collision);
    }
}
