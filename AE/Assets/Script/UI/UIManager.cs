using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject Inventory;
    public bool isInven = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            if(!isInven)
            {
                OpenInven();
            }
            else if(isInven)
            {
                CloseInven();
            }
        }    
    }
    public void CloseInven()
    {
        Inventory.SetActive(false);
        Time.timeScale = 1.0f;
        isInven = false;
    }
    public void OpenInven()
    {
        Inventory.SetActive(true);
        Time.timeScale = 0.5f;
        isInven = true;
    }
}
