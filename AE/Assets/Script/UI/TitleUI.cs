using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameStart()
    {
        SceneManager.LoadScene("Map");
    }

    public void OnGameQuit()
    {
        Application.Quit();
    }
}
