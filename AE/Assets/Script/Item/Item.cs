using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Vector2 orgPos = Vector2.zero;
    private void Awake()
    {
        orgPos = transform.position;
        StartCoroutine(CoinRotating());
    }

    private void Update()
    {
    }

    IEnumerator CoinRotating()
    {
        while (true)
        {
            transform.Rotate(Vector2.up * Time.deltaTime * 360f, Space.World);
            yield return null;
        }
    }
}
