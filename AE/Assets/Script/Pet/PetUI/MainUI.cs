using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    bool isCount = true;

    // ���� ������Ʈ(�÷��̾�,����,UI����,����,Ʃ�丮�� ������)
    public GameObject Player = null;
    public GameObject Wolf = null;
    public GameObject UIWolf = null;
    public GameObject TransparentWall = null;
    public GameObject TutoSlime = null;

    // UI �׸�
    public GameObject HPbar = null;
    public GameObject MapUI = null;
    public GameObject Setting = null;

    // Tuto 1

    // �÷��̾� ���
    public GameObject PlayerSC1 = null;
    public GameObject PlayerSC2 = null;
    public GameObject PlayerSC3 = null;
    public GameObject PlayerSC4 = null;
    // UI���� ���
    public GameObject TutoSC1 = null;
    public GameObject TutoSC2 = null;
    public GameObject TutoSC3 = null;
    public GameObject TutoSC4 = null;
    public GameObject TutoSC5 = null;
    public GameObject TutoSC6 = null;

    // ������ ���� �� ���

    // �÷��̾� ���
    public GameObject PlayerSC5 = null;
    // ���� ���
    public GameObject TutoSC7 = null;

    public GameObject TutoEnd = null;

    // 2-1 ���
    public GameObject BasicDragonCanvas = null;

    // �÷��̾� ���
    public GameObject PlayerSC6 = null;
    public GameObject PlayerSC7 = null;
    //�巡�� ���
    public GameObject DragonSC1 = null;
    public GameObject DragonSC2 = null;

    // Ʃ�丮�� ��縦 ��� int�� ī��Ʈ
    public int TutoCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        // ī��Ʈ ����
       StartCoroutine(TutoCountPlus());
    }

    private void Awake()
    {
        // �÷��̾� ��� ���� Find
        GameObject PlayerScriptControl = GameObject.Find("Player");
        Player = PlayerScriptControl;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSC1 && TutoCount == 1 && !PlayerSC1.activeSelf) 
            PlayerSC1.SetActive(true); // Zzz...Zzz...
        if (TutoSC1 && TutoCount == 3 && !TutoSC1.activeSelf) 
            TutoSC1.SetActive(true); // ??? : ������ �пп�!!!(�Ͼ!!!)
        if (PlayerSC2 && TutoCount == 5 && !PlayerSC2.activeSelf) 
            PlayerSC2.SetActive(true); // ����..... ����..? ���� �����..?
        if (TutoSC2 && TutoCount == 7 && !TutoSC2.activeSelf) 
            TutoSC2.SetActive(true); // ���� : ��!�п�(�ȳ�! ������ �ݰ���)
        if (PlayerSC3 && TutoCount == 9 && !PlayerSC3.activeSelf)
            PlayerSC3.SetActive(true); // �� ����� ����..?
        if (TutoSC3 && TutoCount == 11 && !TutoSC3.activeSelf) 
            TutoSC3.SetActive(true); // ���� : �и�������~! (�� ���� ��Ȱ�� ���� ������ ������ ������� �����~!)
        if (TutoSC4 && TutoCount == 15 && !TutoSC4.activeSelf)
        {
            TutoSC4.SetActive(true); // ���� : ��!(�ѹ� ����Ű�� ������!)
            if (!Player.GetComponent<SpearMan>().enabled) Player.GetComponent<SpearMan>().enabled = true;
        }
        if (TutoSC5 && TutoCount == 20 && !TutoSC5.activeSelf) 
            TutoSC5.SetActive(true); // ���� : �пп�!! (�̹��� �ѹ� Z[�뽬],X[����]�� ������!!)
        if (TutoSC6 && TutoCount == 25 && !TutoSC6.activeSelf) 
            TutoSC6.SetActive(true); // ���� : ��!�п� (���߾�! �׷� �̹��� �տ��ִ� �������� ��ƺ���)
        if (PlayerSC4 && TutoCount == 28 && !PlayerSC4.activeSelf)
        {
            PlayerSC4.SetActive(true); // ����... ���İ�...!
            TutoSlime.SetActive(true);
        }
        if (TutoCount == 29 && UIWolf.activeSelf) UIWolf.SetActive(false); // UI���� ����
        if (TutoCount == 29 && !Wolf.activeSelf) Wolf.SetActive(true); // ���� ����
        if (TutoCount == 30 && TutoEnd.activeSelf)
        {
            TutoEnd.SetActive(true);
            HPbar.SetActive(true);
            MapUI.SetActive(true);
            Setting.SetActive(true);
            Destroy(TransparentWall);
            StopAllCoroutines();
        }
        if (PlayerSC5 && !TutoSlime && !PlayerSC5.activeSelf)
        {
            TutoCount = 33;
            HPbar.SetActive(false);
            MapUI.SetActive(false);
            Setting.SetActive(false);
            PlayerSC5.SetActive(true); // ���..���... (���� ���ڰ� ���ƽ���)
            StartCoroutine(TutoCountPlus());
        }
        if (TutoSC7 && !TutoSlime && !TutoSC7.activeSelf && TutoCount == 33) 
            TutoSC7.SetActive(true); 
        // ���� : ��~~!! ��!!! (���߾�~~!!���� ������� �ʿ��ִ� ��� ���͸� ����ؼ� ���� ���������� �Ѿ����!!!)
        else if(!TutoSC7 && !HPbar.activeSelf && TutoCount == 37)
        {
            HPbar.SetActive(true);
            MapUI.SetActive(true);
            Setting.SetActive(true);
            StopAllCoroutines();
            isCount = false;
        }
        if (BasicDragonCanvas && BasicDragonCanvas.activeSelf && !isCount)
        {
            isCount = true;
            StartCoroutine(TutoCountPlus());
        }
        if(TutoCount == 39)
        {
            DragonSC1.SetActive(true);
        }
        if(TutoCount == 41)
        {
            PlayerSC6.SetActive(true);
        }
        if(TutoCount == 43)
        {
            DragonSC2.SetActive(true);
        }
        if(TutoCount == 45)
        {
            PlayerSC7.SetActive(true);
        }
    }
    // ī��Ʈ�� ������ �Լ�.
    IEnumerator TutoCountPlus()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            TutoCount += 1;
        }
    }
    void QuestClear(GameObject monster)
    {

    }
}
