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
    public bool isInsidePortal;

    public int portalIndex = 0;
    // 1-1 -> 2-1 : 1
    // 2-1 -> 2-2 : 2
    // 2-2 -> 2-3 : 3
    // 2-3 -> 3-1 : 4
    // 3-1 -> 3-2 : 5
    // 3-2 -> 3-3 : 6
    

    Map2_CameraLimit map2_CameraLimit;

    // Start is called before the first frame update
    void Start()
    {
        map2_CameraLimit.Teleport();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && isInsidePortal == true) 
        {
            usePortal = true;
        }
        if(Input.GetKeyUp(KeyCode.F) && isInsidePortal == true)
        {
            usePortal = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIImage.SetActive(true);
        isInsidePortal = true;
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

            switch(portalIndex)
            {
                case 1:
                    // 2 - 1 狼 规 力茄
                    map2_CameraLimit.xMax = 4.0f;
                    map2_CameraLimit.xMin = -27.0f;
                    map2_CameraLimit.yMax = -28.0f;
                    map2_CameraLimit.yMin = -37.5f;
                    map2_CameraLimit.Teleport();
                    break;
                case 2:
                    // 2 - 2 狼 规 力茄
                    map2_CameraLimit.xMax = 52.0f;
                    map2_CameraLimit.xMin = 29.0f;
                    map2_CameraLimit.yMax = -27.5f;
                    map2_CameraLimit.yMin = -37.5f;
                    map2_CameraLimit.Teleport();
                    break;
                case 3:
                    // 2 - 3 狼 规 力茄
                    map2_CameraLimit.xMax = 97.3f;
                    map2_CameraLimit.xMin = 84.5f;
                    map2_CameraLimit.yMax = -29.5f;
                    map2_CameraLimit.yMin = -37.5f;
                    map2_CameraLimit.Teleport();
                    break;
                case 4:
                    // 3 - 1 狼 规 力茄
                    map2_CameraLimit.xMax = 1.2f;
                    map2_CameraLimit.xMin = -23.3f;
                    map2_CameraLimit.yMax = -50.5f;
                    map2_CameraLimit.yMin = -62.5f;
                    map2_CameraLimit.Teleport();
                    break;
                case 5:
                    // 3 - 2 狼 规 力茄
                    map2_CameraLimit.xMax = 52.3f;
                    map2_CameraLimit.xMin = 26.8f;
                    map2_CameraLimit.yMax = -50.5f;
                    map2_CameraLimit.yMin = -62.5f;
                    map2_CameraLimit.Teleport();
                    break;
                case 6:
                    // 3 - 3 狼 规 力茄
                    map2_CameraLimit.xMax = 97.2f;
                    map2_CameraLimit.xMin = 81.8f;
                    map2_CameraLimit.yMax = -52.5f;
                    map2_CameraLimit.yMin = -62.5f;
                    map2_CameraLimit.Teleport();
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UIImage.SetActive(false);
        isInsidePortal = true;
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
