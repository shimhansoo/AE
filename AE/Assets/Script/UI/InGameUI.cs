using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    bool puaseActive  = false;

    public Image pauseGame;

    Image thisImg;
    public Sprite pauseIcon;
    public Sprite resumeIcon;


    public GameObject settingUI;
    // Start is called before the first frame update
    void Start()
    {
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseBtn()
    {
        if (puaseActive)
        {
            Time.timeScale = 1;
            puaseActive = false;
            thisImg.sprite = pauseIcon;
            pauseGame.color = new Color(0, 0, 0, 0);
            
        }
        else
        {
            Time.timeScale = 0;
            puaseActive = true;
            thisImg.sprite = resumeIcon;
            pauseGame.color = new Color(0, 0, 0, 0.5f);
        }
    }
    public void SettingBtn()
    {
        Time.timeScale = 0;
        puaseActive = true;
        pauseGame.color = new Color(0, 0, 0, 0.5f);
        settingUI.SetActive(true); 
    }
    public void CloseBtn()
    {
        Time.timeScale = 1;
        puaseActive = false;
        pauseGame.color = new Color(0, 0, 0, 0);
        settingUI.SetActive(false);
    }
    public void ResetBtn()
    {
        Time.timeScale = 1;
        puaseActive = false;
        pauseGame.color = new Color(0, 0, 0, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitBtn()
    {
        Time.timeScale = 1;
        puaseActive = false;
        pauseGame.color = new Color(0, 0, 0, 0);
        SceneManager.LoadScene("Title");
    }
}
