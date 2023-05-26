using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Map_Portal : MonoBehaviour
{
    public Transform spwanPoint;
    public Image image;
    public GameObject UIImage;
    public bool usePortal;
    public bool isInsidePortal;

    public GameObject oneMini;
    public GameObject secondMini;
    public GameObject thirdMini;
    public GameObject fourthMini;
    public GameObject boss;
    public GameObject miniBoss;
    public GameObject fifthMini;
    public GameObject sixthMini;
    
    public GameObject seventhMini;

    public int portalIndex = 0;

    // 1-1 -> 2-1 : 1 ������(5)

    // 2-1 -> 2-2 : 2 ������(3),��ũ(2)

    // 2-2 -> 2-3 : 3 ������(2),��ũ(1),����(3)

    // 2-3 -> 3-1 : 4 ����(1)

    // 3-1 -> 3-2 : 5 ����(3),������(1)

    // 3-2 -> 3-3 : 6

    // BasicDragon Rep
    public GameObject BasicDragon;

    // Dragon Canvas
    public GameObject BasicDragonCanvas; // 2-1 BasicDragon���� ĵ����
    public GameObject EvolutionCanvas; // 3-1 �巡�� ��ȭ ĵ����

    // ���� �ʿ��� ���͸� �� ���� �ʰ� ��Ż ��ȣ�ۿ��� �Է��� �� �ߴ� UI���
    public GameObject warningScript;

    // 1-1 Ŭ����� �ߴ� Ʃ�丮�� ����
    public GameObject TutoSC8;

    // ���� �� ���� ���ε� ������Ʈ
    public GameObject monsterCheckobj1;
    public GameObject monsterCheckobj2;
    public GameObject monsterCheckobj3;
    public GameObject monsterCheckobj4;
    public GameObject monsterCheckobj5;
    public GameObject monsterCheckobj6;

    // ���� �ʿ� ���Ͱ� �� �׾����� üũ
    protected bool monsterDeathCheck = false;

    // �� �̵� �� ���� ���� �ð�
    public float appearTime = 3.0f;

    // UI�׸�
    public GameObject HPbar = null;
    public GameObject MapUI = null;
    public GameObject Setting = null;

    Map2_CameraLimit map2_CameraLimit;
    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        map2_CameraLimit.Teleport();
    }

    // Update is called once per frame
    void Update()
    {
        // isInsidePortal ��Ż �������� ������
        if (Input.GetKeyDown(KeyCode.F) && isInsidePortal == true && monsterDeathCheck && !warningScript.activeSelf) 
        {
            usePortal = true;
            if(TutoSC8) Destroy(TutoSC8);
        }
        else if(Input.GetKeyDown(KeyCode.F) && isInsidePortal == true && !monsterDeathCheck && !warningScript.activeSelf)
        {
            StartCoroutine(Warning());
        }
        if(Input.GetKeyUp(KeyCode.F) && isInsidePortal == true)
        {
            usePortal = false;
        }
        if (!monsterCheckobj1 && !monsterCheckobj2 && !monsterCheckobj3 && !monsterCheckobj4 && !monsterCheckobj5 && !monsterCheckobj6 && !monsterDeathCheck)
        {
            if(TutoSC8)
            {
                StartCoroutine(uiStopping()); // ��� ���ö� UI�̹��� ��� ���ִ� �ڷ�ƾ
                TutoSC8.SetActive(true);
            }
            if(monsterDeathCheck != true) monsterDeathCheck = true; // ���Ͱ� �� �׾����� true
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIImage.SetActive(true);
        isInsidePortal = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && usePortal == true)
        {
            collision.transform.position = spwanPoint.position;
            if (image != null)
            {
                StartCoroutine(FadeCoroutine());
            }

            switch(portalIndex)
            {
                case 1:
                    // 2 - 1 �� �� ����
                    map2_CameraLimit.xMax = 4.0f;
                    map2_CameraLimit.xMin = -27.0f;
                    map2_CameraLimit.yMax = -28.0f;
                    map2_CameraLimit.yMin = -37.5f;
                    map2_CameraLimit.Teleport();
                    map2_CameraLimit.SecondStage();
                    oneMini.SetActive(false);
                    secondMini.SetActive(true);
                    if (BasicDragonCanvas) BasicDragonCanvas.SetActive(true); // basic�巡�� ���� ��� ĵ����
                    Instantiate(Resources.Load("Pet/Dragon/BasicDragon/BasicDragon"), transform.position, Quaternion.identity); // basic�巡�� ����
                    break;
                case 2:
                    // 2 - 2 �� �� ����
                    map2_CameraLimit.xMax = 52.0f;
                    map2_CameraLimit.xMin = 29.0f;
                    map2_CameraLimit.yMax = -27.5f;
                    map2_CameraLimit.yMin = -37.5f;
                    map2_CameraLimit.Teleport();
                    secondMini.SetActive(false);
                    thirdMini.SetActive(true);
                    break;
                case 3:
                    // 2 - 3 �� �� ����
                    map2_CameraLimit.xMax = 97.3f;
                    map2_CameraLimit.xMin = 84.5f;
                    map2_CameraLimit.yMax = -29.5f;
                    map2_CameraLimit.yMin = -37.5f;
                    map2_CameraLimit.Teleport();
                    thirdMini.SetActive(false);
                    fourthMini.SetActive(true);
                    boss.SetActive(true);
                    break;
                case 4:
                    // 3 - 1 �� �� ����
                    map2_CameraLimit.xMax = 1.2f;
                    map2_CameraLimit.xMin = -23.3f;
                    map2_CameraLimit.yMax = -50.5f;
                    map2_CameraLimit.yMin = -62.5f;
                    map2_CameraLimit.Teleport();
                    map2_CameraLimit.ThirdStage();
                    fourthMini.SetActive(false);
                    fifthMini.SetActive(true);
                    if(EvolutionCanvas) EvolutionCanvas.SetActive(true);
                    
                    break;
                case 5:
                    // 3 - 2 �� �� ����
                    map2_CameraLimit.xMax = 52.3f;
                    map2_CameraLimit.xMin = 26.8f;
                    map2_CameraLimit.yMax = -50.5f;
                    map2_CameraLimit.yMin = -62.5f;
                    map2_CameraLimit.Teleport();
                    fifthMini.SetActive(false);
                    sixthMini.SetActive(true);
                    miniBoss.SetActive(true);
                    Debug.Log("�̴Ϻ���");
                    cam.GetComponent<CameraShake>().MapShake();
                    break;
                case 6:
                    // 3 - 3 �� �� ����
                    map2_CameraLimit.xMax = 97.2f;
                    map2_CameraLimit.xMin = 81.8f;
                    map2_CameraLimit.yMax = -52.5f;
                    map2_CameraLimit.yMin = -62.5f;
                    map2_CameraLimit.Teleport();
                    sixthMini.SetActive(false);
                    seventhMini.SetActive(true);
                    miniBoss.SetActive(false);
                    cam.GetComponent<CameraShake>().MapShakeEnd();
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        UIImage.SetActive(false);
        isInsidePortal = true;
    }
    private void Awake()
    {
        if(GameObject.Find("Plyaer").GetComponent<Map2_CameraLimit>() != null)
        {
            map2_CameraLimit = GameObject.Find("Plyaer").GetComponent<Map2_CameraLimit>();
        }
        else if (GameObject.Find("Player").GetComponent<Map2_CameraLimit>() != null)
        {
            map2_CameraLimit = GameObject.Find("Player").GetComponent<Map2_CameraLimit>();
        }

    }
    IEnumerator FadeCoroutine()
    {
        float fadeCount = 1.0f;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }

    // ���� �ʿ��� ���͸� �� ���� �ʰ� ��Ż ��ȣ�ۿ��� �Է��� �� �ߴ� UI��� �ڷ�ƾ �Լ�
    IEnumerator Warning() 
    {
        StartCoroutine(uiStopping());
        warningScript.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        warningScript.SetActive(false);
    }
    // ��� ���ö� UI��� ���ִ� �ڷ�ƾ �Լ�
    IEnumerator uiStopping()
    {
        if (HPbar != null) HPbar.SetActive(false);
        if (MapUI != null) MapUI.SetActive(false);
        if (Setting != null) Setting.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        if (HPbar != null) HPbar.SetActive(true);
        if (MapUI != null) MapUI.SetActive(true);
        if (Setting != null) Setting.SetActive(true);
    }
    // ���� ��Ÿ���� �ϴ°� ���� ing
    IEnumerator monsterAppearing(float Appeartime)
    {
        yield return new WaitForSeconds(Appeartime);
        if (monsterCheckobj1) monsterCheckobj1.SetActive(true);
        if (monsterCheckobj2) monsterCheckobj2.SetActive(true);
        if (monsterCheckobj3) monsterCheckobj3.SetActive(true);
        if (monsterCheckobj4) monsterCheckobj4.SetActive(true);
        if (monsterCheckobj5) monsterCheckobj5.SetActive(true);
        if (monsterCheckobj6) monsterCheckobj6.SetActive(true);
    }
}
