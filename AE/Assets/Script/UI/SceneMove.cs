using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    public GameObject LoadImage;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        LoadImage.SetActive(true);
        StartCoroutine(Loading());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Loading()
    {
        float fadeCount = 1.0f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
        LoadImage.SetActive(false);
    }
}
