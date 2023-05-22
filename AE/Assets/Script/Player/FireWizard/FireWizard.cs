using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWizard : BattleSystem
{    
    public GameObject FireWizardAdogen; 
    public GameObject Firebolt; 
    public GameObject Fireblast; 
    public GameObject FireWizardMagicCircle;
    public GameObject AdogenCastingBar1;
    public Slider AdogenCastingBar;
    float fireWizardSkill1 = 7f;
    float fireWizardSkill2 = 7f;
    bool isCasting=false;
    bool isActionLimit=true;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        playerCurHp = playerMaxHp;
        StartCoroutine(AirChecking());
    }

    private void FixedUpdate()
    {
        if (isLive)
        {
            OnMove();
        }
    }
    // Update is called once per frame
    void Update()
    {

        AdogenCastingBar1.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y+0.5f));
        if (isLive)
        {
            playerCurrentMoveSpeed = playerMoveSpeed + additionalSpeed;
            //�¿����
            Scalesetting();
            if (isActionLimit)
            {
                //�뽬
                Dash();
                //�⺻���� �ð� ����
                attackTime += Time.deltaTime * attackSpeed;
                if (attackTime >= 0.5f)
                {
                    if (Input.GetKey(KeyCode.X))
                    {
                        myAnim.SetTrigger("Attack");
                        GameObject temp = Instantiate(Firebolt, attackPoint.position, Quaternion.identity);
                        temp.transform.SetParent(gameObject.transform);
                        attackTime = 0.0f;
                    }
                }
                //skill 1��
                fireWizardSkill1 += Time.deltaTime;
                if (fireWizardSkill1 >= 7f)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        GameObject fireWizardMagicCircle = Instantiate(FireWizardMagicCircle, new Vector2(attackPoint.position.x, attackPoint.position.y), Quaternion.identity);
                        fireWizardMagicCircle.transform.SetParent(gameObject.transform);
                        GameObject FireBlast = Instantiate(Fireblast, new Vector2(attackPoint.position.x, attackPoint.position.y + 0.2f), Quaternion.identity);
                        FireBlast.transform.SetParent(gameObject.transform);
                        fireWizardSkill1 = 0.0f;
                    }
                }
            }
            //skill 2��
            fireWizardSkill2 += Time.deltaTime;
            if (fireWizardSkill2 >= 7f)
            {
                Skill2Casting();
            }
            
            //���� ���� ����
            //isJump = rayHitDownLeft || rayHitDownRight ? isJump = false : isJump = true;
            isJump = groundCheck ? isJump = false : isJump = true;
            jumpCool += Time.deltaTime;
            if (!isJump && jumpCool >= 0.5f)
            {
                OnJump();
            }
            else
            {
                collisionCheck();
            }
        }
    }
    public void Skill2Casting()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isCasting)
        {
            myAnim.ResetTrigger("Skill2Exit");
            isCasting = true;
            myAnim.SetTrigger("Skill2");
            isActionLimit = false;
            AdogenCastingBar.gameObject.SetActive(true);
        }
        if (Input.GetKey(KeyCode.S) && isCasting)
        {
            AdogenCastingBar.value += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            if (AdogenCastingBar.value >= 1)
            {
                Instantiate(FireWizardAdogen, attackPoint.position, Quaternion.identity, gameObject.transform);
                fireWizardSkill2 = 0;
            }
            AdogenCastingBar.gameObject.SetActive(false);
            isActionLimit = true;
            isCasting = false;
            AdogenCastingBar.value = 0f;
            myAnim.SetTrigger("Skill2Exit");
        }
    }
}
