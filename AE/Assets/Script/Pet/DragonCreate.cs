using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonCreate : MonoBehaviour
{
    public GameObject FireDragon;
    public GameObject DarkDragon;
    public GameObject BasicDragon;
    public GameObject Canvas;
    Transform player = null;
    private void Awake()
    {
        GameObject PlayerPos = GameObject.Find("DragonTargetPlayerPos");
        player = PlayerPos.transform;
        BasicDragon = GameObject.Find("BasicDragon(Clone)");
    }
    public void CreatFireDragon()
    {
        StartCoroutine(CreateDragon(FireDragon));
    }
    public void CreatDarkDragon()
    {
        StartCoroutine(CreateDragon(DarkDragon));
    }

    IEnumerator CreateDragon(GameObject DRG)
    {
        Destroy(BasicDragon);
        yield return new WaitForSeconds(1.5f);        
        Destroy(Canvas);
        Instantiate(DRG, player.position, Quaternion.identity);
    }
}
