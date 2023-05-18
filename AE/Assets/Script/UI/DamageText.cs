using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    TextMeshPro myText;
    float alphaIntensity = 255;

    private void Awake()
    {
        myText = GetComponentInChildren<TextMeshPro>();
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        myText.alpha = alphaIntensity/255;
        transform.Translate(Vector2.up * Time.deltaTime, Space.World);
        if (alphaIntensity > 0) alphaIntensity -= (255 * Time.deltaTime);
        else Destroy(gameObject);
    }

    public void ChangeDamageText(float dmg)
    {
        if(dmg > 0)
        {
            myText.text = dmg.ToString();
        }
        else
        {
            myText.color = Color.green;
            myText.text = Mathf.Abs(dmg).ToString();
        }
    }
}
