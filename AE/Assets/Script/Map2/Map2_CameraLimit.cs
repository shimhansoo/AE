using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map2_CameraLimit : MonoBehaviour
{

    public GameObject target;
    public Camera mainCam;

    public float xMin = -26.0f, xMax = 4.0f;
    public float yMin = -13.0f, yMax = 0.0f;

    public float x = 0.0f;
    public float y = 0.0f;

    public float xPos = 0.0f;
    public float yPos = 0.0f;

    public Material cave;
    public Material iceCave;
    public Material forest;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        x = transform.position.x;
        y = transform.position.y;
        xPos = Mathf.Clamp(x , xMin, xMax);
        yPos = Mathf.Clamp(y , yMin, yMax);
        
        //target.transform.position = new Vector3(xPos, yPos + 3.0f, -10);
    }
    private void FixedUpdate()
    {
        Vector3 pos = new Vector3(xPos, yPos + 3.0f, -10);
        target.transform.position = Vector3.Lerp(target.transform.position, pos, Time.deltaTime * 5f);
    }
    public void Teleport()
    {
        target.transform.position = transform.position;
    }
    public void SecondStage()
    {
        mainCam.GetComponent<Skybox>().material = forest;
    }
    public void ThirdStage()
    {
        mainCam.GetComponent<Skybox>().material = iceCave;
    }
}
