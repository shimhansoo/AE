using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkDragonLaserSkill : PetProperty
{
    public GameObject Laser = null;
    // Start is called before the first frame update
    void Start()
    {
        PetAnim.SetTrigger("isSkill");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnLaser()
    {
        Laser.SetActive(true);
    }
    void OffLaser()
    {
        Laser.SetActive(false);
    }

    void OnAttack()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapBoxAll(Laser.transform.position, new Vector2(5.0f,0.5f),0.0f, MonsterMask);
        foreach (Collider2D enemy in hitEnemys)
        {
            enemy.GetComponent<GameManager.IBattle>().OnTakeDamage(20.0f);  
        }       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(Laser.transform.position, new Vector2(5.0f, 0.5f));
    }
}
