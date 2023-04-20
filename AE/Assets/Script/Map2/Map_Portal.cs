using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Map_Portal : MonoBehaviour
{
    public Transform spwanPoint;
    public Image image;
    public GameObject UIImage;
    public bool usePortal;

    Map2_CameraLimit map2_CameraLimit;

    // Start is called before the first frame update
    void Start()
    {
        map2_CameraLimit.Teleport();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) || Input.GetKey(KeyCode.F)) 
        {
            usePortal = true;
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            usePortal = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIImage.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && usePortal == true)
        {
            collision.transform.position = spwanPoint.position;
            if (image != null)
            {
                StartCoroutine(FadeCoroutine());
            }

            map2_CameraLimit.xMax = 4.0f;
            map2_CameraLimit.xMin = -27.0f;
            map2_CameraLimit.yMax = -28.0f;
            map2_CameraLimit.yMin = -39.0f;
            map2_CameraLimit.Teleport();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UIImage.SetActive(false);
    }
    private void Awake()
    {
        map2_CameraLimit = GameObject.Find("Player").GetComponent<Map2_CameraLimit>();
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
