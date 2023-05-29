using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Map_Bidrectional_Portal : MonoBehaviour
{
    public Transform spwanPoint;
    public Image image;
    public GameObject UIImage;
    public bool usePortal;
    public bool isInsidePortal;
    

    Map2_CameraLimit map2_CameraLimit;

    // Start is called before the first frame update
    void Start()
    {
        map2_CameraLimit.Teleport();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isInsidePortal)
        {
            usePortal = true;   
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInsidePortal = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && usePortal == true)
        {
            usePortal = false;
            
            collision.transform.position = spwanPoint.position;
            
            if (image != null)
            {
                //StartCoroutine(FadeCoroutine());
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UIImage.SetActive(false);
        isInsidePortal = false;
    }
    private void Awake()
    {
        if (GameObject.Find("Player").GetComponent<Map2_CameraLimit>() != null)
        {
            map2_CameraLimit = GameObject.Find("Player").GetComponent<Map2_CameraLimit>();
        }
        else if (GameObject.Find("Player").GetComponent<Map2_CameraLimit>() != null)
        {
            map2_CameraLimit = GameObject.Find("Player").GetComponent<Map2_CameraLimit>();
        }
    }
    IEnumerator FadeCoroutine()
    {
        float fadeCount = 1.0f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }
}
