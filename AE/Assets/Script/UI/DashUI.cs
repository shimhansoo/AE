using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    public GameObject player;
    public TMP_Text Dash;

    public Image myIcon = null;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
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
        Dash = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // ��ų ������ �ؽ�Ʈ��
        Dash.text = player.GetComponent<CharacterProperty>().dashCount.ToString();
        // ��Ÿ�Ӹ�ŭ Fill Area
        if(player.GetComponent<CharacterProperty>().dashCount != 2)
        {
            myIcon.fillAmount = player.GetComponent<CharacterProperty>().coolTime / 2.0f;
        }
        else
        {
            myIcon.fillAmount = 1.0f;
        }
    }
}
