using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    public TMP_Text myText = null;
    float colorLev = 360;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colorLev > 0) colorLev -= (255 * Time.deltaTime);
        if (colorLev < 0) colorLev = 360;
        myText.color = Color.HSVToRGB(colorLev / 360, 1, 1);
    }
}
