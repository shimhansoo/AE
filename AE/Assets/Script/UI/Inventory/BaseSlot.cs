using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BaseSlot : MonoBehaviour
{
    public List<GameObject> slot = new List<GameObject>(9);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckSlot()
    {
        Debug.Log("IN");
    }
}
