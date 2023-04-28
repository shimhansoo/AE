using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_BackGround : MonoBehaviour
{
    public GameObject BackGroundImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BackGroundImage.transform.Translate(-2 * Time.deltaTime, 0, 0);
        if(BackGroundImage.transform.position.x <= - 7)
        {
            BackGroundImage.transform.position = new Vector3(8, 1, -1);
        }
    }
}
