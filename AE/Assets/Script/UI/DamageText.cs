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
        if (transform.parent.parent.localScale.x < 0) transform.localScale = new Vector3(-1, 1, 1);
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

    public void ChangeTextColor(float dmg, int code = 0)    // 0 : 피격, 1 : 체력 회복
    {
        if(code == 0)
        {
            myText.color = Color.red;
        }
        else
        {
            myText.color = Color.green;
        }
        myText.text = dmg.ToString();
    }
}
