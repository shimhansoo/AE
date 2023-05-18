using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWizard : BattleSystem
{    
    //public GameObject magicCircle; 
    public GameObject Firebolt; 
    public GameObject Fireblast; 
    public GameObject FireWizardMagicCircle;
    public Slider AdogenCastingBar;
    float fireWizardSkill1 = 7f;
    float fireWizardSkill2 = 2f;
    bool test=false;
    // Start is called before the first frame update
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
        if (isLive)
        {
            playerCurrentMoveSpeed = playerMoveSpeed + additionalSpeed;

            //대쉬
            Dash();
            //좌우반전
            Scalesetting();

            //기본공격 시간 제어
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
            //skill 1번
            fireWizardSkill1 += Time.deltaTime;
            if (fireWizardSkill1 >= 7f)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {

                    GameObject fireWizardMagicCircle = Instantiate(FireWizardMagicCircle, new Vector2(attackPoint.position.x, attackPoint.position.y), Quaternion.identity);
                    fireWizardMagicCircle.transform.SetParent(gameObject.transform);
                    GameObject FireBlast = Instantiate(Fireblast, new Vector2(attackPoint.position.x, attackPoint.position.y+0.2f), Quaternion.identity);
                    FireBlast.transform.SetParent(gameObject.transform);
                    fireWizardSkill1 = 0.0f;
                }
            }
            //skill 2번
            fireWizardSkill2 += Time.deltaTime;
            if (fireWizardSkill2 >= 2f)
            {
            fireWizardSkill2 = 0;
            }
                Skill2Casting();

            
            //무한 점프 제어
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
        if (Input.GetKeyDown(KeyCode.Alpha3) && !test)
        {
            test = true;
            /*myAnim.SetBool("isSkill2Casting", true);*/
            myAnim.SetTrigger("Skill2");
        }
        if (Input.GetKey(KeyCode.Alpha3) && test)
        {
            /*myAnim.SetTrigger("Skill2");*/
            AdogenCastingBar.value += 0.1f * Time.deltaTime;
            
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (AdogenCastingBar.value >= 1)
            {
            }
            test = false;
            AdogenCastingBar.value = 0f;
            myAnim.SetTrigger("testExit");
        }
    }
}
