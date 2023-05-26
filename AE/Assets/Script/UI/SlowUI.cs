using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowUI : MonoBehaviour
{
    public GameObject player;
    public TMP_Text Slow;

    public Image myIcon = null;

    public float time = 0.0f;
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
        Slow = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Slow.text = time.ToString();
        myIcon.fillAmount = time / 3.0f;
    }
}
