using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBG : MonoBehaviour
{
    public Image Startbg;
    public int Imagecount = 0;
    public bool Fadeing = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountPlus());
    }
    // Update is called once per frame
    void Update()
    {
        if (Imagecount == 4)
        {
            StartCoroutine(FadeBG());
        }
        if (Imagecount == 29 && Fadeing)
        {
            StartCoroutine(FadeBG());
            Fadeing = false;
        } 
    }
    void fadeBg()
    {
        float fadeBG = 1;

        while(fadeBG >= 0.0f)
        {
            fadeBG -= 0.01f;
            Startbg.color = new Color(0, 0, 0, fadeBG);
        }
    }
    IEnumerator FadeBG()
    {
        float fadeRGB = 1;
        while (fadeRGB >= 0.0f)
        {
            fadeRGB -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            Startbg.color = new Color(0, 0, 0, fadeRGB);
        }
    }
    IEnumerator AppearBG()
    {
        float AppearRGB = 0;
        while (AppearRGB <= 1.0f)
        {
            AppearRGB += 0.01f;
            yield return new WaitForSeconds(0.01f);
            Startbg.color = new Color(0, 0, 0, AppearRGB);
        }
    }
    IEnumerator CountPlus()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            Imagecount += 1;
        }
    }
}
