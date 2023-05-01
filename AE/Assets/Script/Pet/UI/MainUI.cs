using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public GameObject Wolf = null;
    public GameObject UIWolf = null;
    public GameObject PlayerStartScript1 = null;
    public GameObject PlayerStartScript2 = null;
    public GameObject PlayerStartScript3 = null;
    public GameObject PlayerStartScript4 = null;
    public GameObject Tutorial1 = null;
    public GameObject Tutorial2 = null;
    public GameObject Tutorial3 = null;
    public GameObject Tutorial4 = null;
    public GameObject Tutorial5 = null;
    public GameObject Tutorial6 = null;
    public GameObject TutoEnd = null;
    public int TutoCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountPlus());
        /*PlayerStartScript.SetActive(true);*/
    }

    // Update is called once per frame
    void Update()
    {
        if(TutoCount == 1) PlayerStartScript1.SetActive(true);
        if (TutoCount == 3) Tutorial1.SetActive(true);
        if (TutoCount == 5) PlayerStartScript2.SetActive(true);
        if (TutoCount == 7) Tutorial2.SetActive(true);
        if (TutoCount == 9) PlayerStartScript3.SetActive(true);
        if (TutoCount == 11) Tutorial3.SetActive(true);
        if (TutoCount == 15) Tutorial4.SetActive(true);
        if (TutoCount == 20) Tutorial5.SetActive(true);
        if (TutoCount == 25) Tutorial6.SetActive(true);
        if (TutoCount == 28) PlayerStartScript4.SetActive(true);
        if (TutoCount == 29) UIWolf.SetActive(false);
        if (TutoCount == 29) Wolf.SetActive(true);
        if (TutoCount == 30) TutoEnd.SetActive(true);
    }
    IEnumerator CountPlus()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            TutoCount += 1;
        }
    }

    /*void TutorialQuestCheck()
    {
        // �ʹ� Ʃ�丮�󿡼� ����Ű,����Ű�� �Է� �޾Ұų� ������ ����Ʈ�� Ŭ�����ߴٸ� UI�� ���� ���� �Ѿ���ְ� ���ִ� �Լ�!
        // ex) Z,X�� ������� ���� ������. ��ž�ڷ�ƾ CountPlus�� �����ν� 
    }*/
}
