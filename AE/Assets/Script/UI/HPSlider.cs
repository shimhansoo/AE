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
        if(player == null)
        {
            player = GameObject.Find("Player");
        }
        MaxHp = player.GetComponent<CharacterProperty>().playerMaxHp;
        Hp = player.GetComponent<CharacterProperty>().playerMaxHp;
        //if(player.GetComponent<SpearMan>())
        //{
        //    MaxHp = player.GetComponent<SpearMan>().playerCurHp;
        //    Hp = player.GetComponent<SpearMan>().playerCurHp;
        //    Debug.Log(MaxHp);

        //}
        //else if(player.GetComponent<FireWizard>())
        //{
        //    MaxHp = player.GetComponent<SpearMan>().playerCurHp;
        //    Hp = player.GetComponent<SpearMan>().playerCurHp;
        //    Debug.Log(MaxHp);
        //}
        slider.maxValue = MaxHp;
        slider.value = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        Hp = player.GetComponent<PlayerLibrary>().playerCurHp;
        slider.value = Hp;
    }
}
