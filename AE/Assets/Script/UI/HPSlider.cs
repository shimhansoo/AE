using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    public GameObject player;
    float MaxHp;
    float Hp;
    public Slider slider;
    public TMP_Text HPText;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            if (GameObject.Find("Plyaer") != null)
            {
                player = GameObject.Find("Plyaer");
            }
            else if (GameObject.Find("Player") != null)
            {
                player = GameObject.Find("Player");
            }
        }
        MaxHp = player.GetComponent<CharacterProperty>().playerMaxHp;
        Hp = player.GetComponent<CharacterProperty>().playerMaxHp;
        HPText = GetComponentInChildren<TextMeshProUGUI>(); 
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
        MaxHp = player.GetComponent<CharacterProperty>().playerMaxHp;
        slider.maxValue = MaxHp;

        Hp = player.GetComponent<PlayerLibrary>().playerCurHp;
        slider.value = Hp;
        HPText.text = player.GetComponent<PlayerLibrary>().playerCurHp.ToString() + " / " + MaxHp.ToString();
    }
}
