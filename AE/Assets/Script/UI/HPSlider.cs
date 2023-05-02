using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public Slider Slider;
    public float HpValue;
    public float NowHP;
    public GameObject Player;
   
    // Start is called before the first frame update
    void Start()
    {
        HpValue = Player.GetComponent<SpearMan>().playerCurHp;
        NowHP = Player.GetComponent<SpearMan>().playerCurHp;
        Slider.maxValue = HpValue;
    }

    // Update is called once per frame
    void Update()
    {
        NowHP = Player.GetComponent<SpearMan>().playerCurHp;
        Slider.value = NowHP;
    }
}
