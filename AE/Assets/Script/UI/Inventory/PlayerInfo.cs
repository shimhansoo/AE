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
    public TMP_Text Gold;

    public Inventory Inventory;

    public GameObject Player1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP.text = "HP : " + Player1.GetComponent<CharacterProperty>().playerCurHp.ToString();
        Attack.text = "ATK : " + Player1.GetComponent<CharacterProperty>().playerDamege.ToString();
        Speed.text = "SPD : " + Player1.GetComponent<CharacterProperty>().playerCurrentMoveSpeed.ToString();
        Gold.text = Inventory.gold.ToString();

    }
}
