using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public TMP_Text HP;
    public TMP_Text Attack;
    public TMP_Text Speed;

    public GameObject Player1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = Player1.GetComponent<CharacterProperty>().playerCurHp.ToString();
        Attack.text = Player1.GetComponent<CharacterProperty>().playerDamege.ToString();
        Speed.text = Player1.GetComponent<CharacterProperty>().playerCurrentMoveSpeed.ToString();
    }
}
