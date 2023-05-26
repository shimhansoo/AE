using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject SlowDebuff;
    [SerializeField]
    private GameObject player;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<CharacterProperty>().additionalSpeed < 0.0f)
        {
            SlowDebuff.SetActive(true);
        }
        else
        {
            SlowDebuff.SetActive(false);
        }
    }
}
