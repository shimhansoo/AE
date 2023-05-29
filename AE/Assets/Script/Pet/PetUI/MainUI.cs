using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    bool isCount = true;

    // 게임 오브젝트(플레이어,울프,UI울프,투명벽,튜토리얼 슬라임)
    public GameObject Player = null;
    public GameObject Wolf = null;
    public GameObject UIWolf = null;
    public GameObject TransparentWall1 = null; // 첫 튜토리얼 몬스터잡기 1자 벽 없애기
    public GameObject TransparentWall2 = null; // 몬스터잡기 완료후 천장 벽 없애기
    public GameObject TutoSlime = null;
    public GameObject BasicDragon = null;
    public GameObject LastBoss = null;

    // UI 그림
    public GameObject HPbar = null;
    public GameObject MapUI = null;
    public GameObject Setting = null;
    public GameObject DashUI = null;
    public GameObject Clear = null;

    // Tuto 1

    // 플레이어 대사
    public GameObject PlayerSC1 = null;
    public GameObject PlayerSC2 = null;
    public GameObject PlayerSC3 = null;
    public GameObject PlayerSC4 = null;
    // UI늑대 대사
    public GameObject TutoSC1 = null;
    public GameObject TutoSC2 = null;
    public GameObject TutoSC3 = null;
    public GameObject TutoSC4 = null;
    public GameObject TutoSC5 = null;
    public GameObject TutoSC6 = null;

    // 슬라임 잡은 후 대사

    // 플레이어 대사
    public GameObject PlayerSC5 = null;
    // 늑대 대사
    public GameObject TutoSC7 = null;

    public GameObject TutoEnd = null;

    // 2-1 대사
    public GameObject BasicDragonCanvas = null;

    // 플레이어 대사
    public GameObject PlayerSC6 = null;
    public GameObject PlayerSC7 = null;
    //드래곤 대사
    public GameObject DragonSC1 = null;
    public GameObject DragonSC2 = null;


    // 튜토리얼 대사를 띄울 int형 카운트
    public int TutoCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        // 카운트 시작
       StartCoroutine(TutoCountPlus());
    }

    private void Awake()
    {
        // 플레이어 제어를 위한 Find
        //GameObject PlayerScriptControl = GameObject.Find("Player");
        //Player = PlayerScriptControl;
        if (GameObject.Find("Plyaer") != null)
        {
            Player = GameObject.Find("Plyaer");
        }
        else if (GameObject.Find("Player") != null)
        {
            Player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSC1 && TutoCount == 1 && !PlayerSC1.activeSelf) 
            PlayerSC1.SetActive(true); // Zzz...Zzz...
        if (TutoSC1 && TutoCount == 3 && !TutoSC1.activeSelf) 
            TutoSC1.SetActive(true); // ??? : 으르릉 왈왈왈!!!(일어나!!!)
        if (PlayerSC2 && TutoCount == 5 && !PlayerSC2.activeSelf) 
            PlayerSC2.SetActive(true); // 으음..... 뭐야..? 여긴 어디지..?
        if (TutoSC2 && TutoCount == 7 && !TutoSC2.activeSelf) 
            TutoSC2.SetActive(true); // 늑대 : 왈!왈왈(안녕! 만나서 반가워)
        if (PlayerSC3 && TutoCount == 9 && !PlayerSC3.activeSelf)
            PlayerSC3.SetActive(true); // 이 늑대는 뭐지..?
        if (TutoSC3 && TutoCount == 11 && !TutoSC3.activeSelf) 
            TutoSC3.SetActive(true); // 늑대 : 왈르으르왈~! (난 너의 원활한 게임 진행을 도와줄 길라잡이 늑대야~!)
        if (TutoSC4 && TutoCount == 15 && !TutoSC4.activeSelf)
        {
            TutoSC4.SetActive(true); // 늑대 : 왈!(한번 방향키를 눌러봐!)
            //if (!Player.GetComponent<SpearMan>().enabled) Player.GetComponent<SpearMan>().enabled = true;
        }
        if (TutoSC5 && TutoCount == 20 && !TutoSC5.activeSelf) 
            TutoSC5.SetActive(true); // 늑대 : 왈왈왈!! (이번엔 한번 Z[대쉬],X[공격]를 눌러봐!!)
        if (TutoSC6 && TutoCount == 25 && !TutoSC6.activeSelf) 
            TutoSC6.SetActive(true); // 늑대 : 왈! 왈왈! (잘했어! 그러면 앞에있는 몬스터들을 잡아보자!)
        if (PlayerSC4 && TutoCount == 28 && !PlayerSC4.activeSelf)
        {
            PlayerSC4.SetActive(true); // 젠장... 뭐냐고...!
            TutoSlime.SetActive(true); // 튜토리얼 슬라임 등장
        }
        if (TutoCount == 29 && UIWolf.activeSelf) UIWolf.SetActive(false); // UI울프 퇴장
        if (TutoCount == 29 && !Wolf.activeSelf) Wolf.SetActive(true); // 울프 등장
        if (TutoCount == 30 && TutoEnd.activeSelf)
        {
            TutoEnd.SetActive(true);
            HPbar.SetActive(true);
            MapUI.SetActive(true);
            Setting.SetActive(true);
            DashUI.SetActive(true);
            Destroy(TransparentWall1);
            StopAllCoroutines();
        }
        if (PlayerSC5 && !TutoSlime && !PlayerSC5.activeSelf)
        {
            TutoCount = 33;
            HPbar.SetActive(false);
            MapUI.SetActive(false);
            Setting.SetActive(false);
            DashUI.SetActive(false);
            PlayerSC5.SetActive(true); // 허억..허억... (숨을 가쁘게 몰아쉬며)
            Destroy(TransparentWall2);
            StartCoroutine(TutoCountPlus());
        }
        if (TutoSC7 && !TutoSlime && !TutoSC7.activeSelf && TutoCount == 33) 
            TutoSC7.SetActive(true); 
        // 늑대 : 왈~~!! 왈!!! (잘했어~~!!지금 느낌대로 맵에있는 모든 몬스터를 사냥해서 다음 스테이지로 넘어가보자!!!)
        else if(!TutoSC7 && !HPbar.activeSelf && TutoCount == 37 && isCount)
        {
            HPbar.SetActive(true);
            MapUI.SetActive(true);
            Setting.SetActive(true);
            DashUI.SetActive(true);
            StopAllCoroutines();
            TutoCount = 38;
            isCount = false;
        }
        if (BasicDragonCanvas && BasicDragonCanvas.activeSelf && !isCount)
        {
            isCount = true;
            StartCoroutine(TutoCountPlus());
            HPbar.SetActive(false);
            MapUI.SetActive(false);
            Setting.SetActive(false);
            DashUI.SetActive(false);
        }
        if(TutoCount == 39)
            DragonSC1.SetActive(true); // ??? : 크롸롸롸~
        if(TutoCount == 41)
            PlayerSC6.SetActive(true); // 이건 또 무슨소리야..?!
        if(TutoCount == 43)
            DragonSC2.SetActive(true); // 은색 드래곤 : 크롸롸롸~ (안녕~나는 너를 도와줄 애기드래곤이얌 > 3 < !)
        if(TutoCount == 45)
        {
            PlayerSC7.SetActive(true); // 젠장 뭐냐구....!
            HPbar.SetActive(true);
            MapUI.SetActive(true);
            Setting.SetActive(true);
            DashUI.SetActive(true);
        }

        if (!LastBoss) Clear.SetActive(true);
    }
    // 카운트를 돌리는 함수.
    IEnumerator TutoCountPlus()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            TutoCount += 1;
        }
    }
}
