using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // PlayerHP �� PrevHP�� ���� �� Update���� Hp�� �����Ͽ� Perv��
    // �ٸ� ��� PrevHp = Hp �Ҵ� �� ī�޶� ����ũ 
    public GameObject player;
    public float PrevHp;
    public float hp;

    public float shakeTime = 0.5f;
    public float shakeSpeed = 2.0f;
    public float shakeAmount = 4.0f;

    public Transform cam;
    Coroutine mapShake;
    // Start is called before the first frame update
    void Start()
    {
        PrevHp = player.GetComponent<CharacterProperty>().playerCurHp;       
    }

    // Update is called once per frame
    void Update()
    {
        hp = player.GetComponent<CharacterProperty>().playerCurHp;
        if(PrevHp != hp)
        {
            if(PrevHp > hp + 10)
            {
                StartCoroutine(Shake());
            }
            else
            {
                StartCoroutine(LightShake());
            }
            PrevHp = hp;
        }
        
    }
    public void MapShake()
    {
        mapShake = StartCoroutine(MapShaking());
    }
    public void MapShakeEnd()
    {
        StopCoroutine(mapShake);
    }
    IEnumerator LightShake()
    {
        Vector3 originPosition = cam.transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);

            yield return null;
            elapsedTime += Time.deltaTime;
        }
        cam.localPosition = originPosition;
        Debug.Log("LightShake");
    }
    
    IEnumerator Shake()
    {
        Vector3 originPosition = cam.transform.position;
        float elapsedTime = 0.0f;

        while (elapsedTime < shakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount * 2;
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);

            yield return null;
            elapsedTime += Time.deltaTime;
        }
        cam.localPosition = originPosition;
        Debug.Log("Shake");
    }

    public IEnumerator MapShaking()
    {
        while (true)
        {
            Vector3 originPosition = cam.transform.position;
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount * 2;
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);
            yield return null;
            Debug.Log("Map");
        }
    }
}
