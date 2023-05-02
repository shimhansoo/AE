using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public GameObject player;
    float MaxHp;
    float Hp;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        MaxHp = player.GetComponent<SpearMan>().playerCurHp;
        Hp = player.GetComponent<SpearMan>().playerCurHp;

        slider.maxValue = MaxHp;
        slider.value = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        Hp = player.GetComponent<SpearMan>().playerCurHp;
        slider.value = Hp;
    }
}
