using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Monster
{
    public Vector2 MoveArea;
    float myDir = 0.0f;
    public float moveSpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        switch(Random.Range(0,0))
        {
            case 0:
                myDir = -1.0f;
                break;
            case 1:
                myDir = 1.0f;
                break;
        }
        StartCoroutine(Dropping(0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * myDir * moveSpeed * Time.deltaTime);
        if(transform.position.x <= MoveArea.x)
        {
            myDir *= -1.0f;
            transform.position = new Vector3(MoveArea.x, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= MoveArea.y)
        {
            myDir *= 1.0f;
            transform.position = new Vector3(MoveArea.y, transform.position.y, transform.position.z);
        }

    }
    IEnumerator Dropping(float delay)
    {
        while(true)
        {
            GameObject obj = Instantiate(Resources.Load("Item"), transform.position, Quaternion.identity) as GameObject;
            int count = System.Enum.GetValues(typeof(MushromSkill.Type)).Length;
            obj.GetComponent<MushromSkill>().SetType((MushromSkill.Type)Random.Range(0, count - 1));
            yield return new WaitForSeconds(delay);
        }
    }
}
