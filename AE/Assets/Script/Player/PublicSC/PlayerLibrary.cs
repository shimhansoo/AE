using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D.Animation;
public class PlayerLibrary : BattleSystem
{
    public SpriteLibrary spriteLib = null;
    public SpriteLibraryAsset s1 = null;
    public SpriteLibraryAsset s2 = null;
    public SpriteLibraryAsset s3 = null;
    bool isOnAttack = false;
    
    //wizard
    public Slider AdogenCastingBar;
    float fireWizardSkill1 = 7f;
    float fireWizardSkill2 = 7f;
    bool isActionLimit = true;
    bool isCasting = false;

    //SpearMan
    protected float playerSkillMoveSpeed_1 = 0f;
    protected float playerSkillDamage_1 = 0f;
    float spearmanSkillCoolTime1 = 7.0f;
    float spearmanSkillCoolTime2 = 10.0f;
    enum Class
    {
        BasePlayer, SpearMan, FireWizard, Create
    }

    Class myClass = Class.Create;
    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        playerCurHp = playerMaxHp;
        StartCoroutine(AirChecking());
        myClass = Class.BasePlayer;
        isOnAttack = false;
    }
    private void FixedUpdate()
    {
        if (isLive)
        {
            OnMove();
        }
    }
    void ChageClass(Class s)
    {
        if (s == myClass) return;
        myClass = s;
        switch (myClass)
        {
            case Class.BasePlayer:
                break;
            case Class.SpearMan:
                break;
            case Class.FireWizard:
                break;
            default:
                Debug.Log("처리되지 않은 직업군");
                break;
        }
    }
    void ClassProcess()
    {
        switch (myClass)
        {
            case Class.BasePlayer:
                isOnAttack = false;
                break;

            case Class.SpearMan:
                SpeaMan();
                break;

            case Class.FireWizard:
                FireWizard();
                break;

            default:
                Debug.Log("처리되지 않은 직업군");
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) { spriteLib.spriteLibraryAsset = s1; ChageClass(Class.SpearMan); isOnAttack = true; }
        if (Input.GetKeyDown(KeyCode.F2)) { spriteLib.spriteLibraryAsset = s2; ChageClass(Class.FireWizard); isOnAttack= false; }
        if (Input.GetKeyDown(KeyCode.F3)) { spriteLib.spriteLibraryAsset = s3; ChageClass(Class.BasePlayer); isOnAttack = true; }
        ClassProcess();
        

        if (isLive)
        {
            playerCurrentMoveSpeed = playerMoveSpeed + additionalSpeed;
            spearmanSkillCoolTime1 += Time.deltaTime;
            spearmanSkillCoolTime2 += Time.deltaTime;
            fireWizardSkill1 += Time.deltaTime;
            fireWizardSkill2 += Time.deltaTime;
            attackTime += Time.deltaTime * attackSpeed;
            //대쉬
            Dash();
            //좌우반전
            Scalesetting();
            //근접공격
            if (isOnAttack)
            {
                if (attackTime >= 0.5f)
                {
                    if (Input.GetKey(KeyCode.X))
                    {
                        myAnim.SetTrigger("Attack");
                        attackTime = 0.0f;
                    }
                }
            }
            //원거리 공격
            if (!isOnAttack)
            {
                if (attackTime >= 0.5f)
                {
                    if (Input.GetKey(KeyCode.X))
                    {
                        myAnim.SetTrigger("LongAttack");
                        
                        attackTime = 0.0f;
                    }
                }
            }
            //무한 점프 제어
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
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawSphere(new Vector2(transform.position.x, transform.position.y - 0.5f), 0.3f);
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

    IEnumerator Berserk()
    {
        playerSkillMoveSpeed_1 = playerMoveSpeed;
        playerSkillDamage_1 = playerDamege;

        playerMoveSpeed *= 1.5f;
        playerDamege *= 2.0f;
        attackSpeed = 5.0f;

        GameObject temp = Instantiate(Resources.Load("Player/SpearManSkill1"), new Vector2(transform.position.x, transform.position.y + 0.2f), Quaternion.identity) as GameObject;
        temp.transform.SetParent(this.transform);
        yield return new WaitForSeconds(5.0f);

        Destroy(temp);
        playerMoveSpeed = playerSkillMoveSpeed_1;
        playerDamege = playerSkillDamage_1;
        attackSpeed = 1.0f;
    }

    void FireWizard()
    {
        //AdogenCastingBar.transform.position = Camera.main.WorldToScreenPoint(new Vector2(transform.position.x, transform.position.y + 0.5f));
        //Skill2Casting();
        if (fireWizardSkill1 >= 7f)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                GameObject fireWizardMagicCircle = Instantiate(Resources.Load("Player/FireWizardMagicCircle"), new Vector2(attackPoint.position.x, attackPoint.position.y), Quaternion.identity) as GameObject;
                fireWizardMagicCircle.transform.SetParent(gameObject.transform);
                GameObject FireBlast = Instantiate(Resources.Load("Player/FireBlast"), new Vector2(attackPoint.position.x, attackPoint.position.y + 0.2f), Quaternion.identity) as GameObject;
                FireBlast.transform.SetParent(gameObject.transform);
                fireWizardSkill1 = 0.0f;
            }
        }
    }



    void SpeaMan()
    {
        //스킬 1
        if (spearmanSkillCoolTime1 >= 7.0f)//7초 이후
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                spearmanSkillCoolTime1 = 0f;
                StartCoroutine(Berserk());
            }
        }
        //스킬 2
        if (spearmanSkillCoolTime2 >= 10.0f)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                spearmanSkillCoolTime2 = 0f;
                GameObject temp = Instantiate(Resources.Load("Player/SpearManSkill2"), new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity) as GameObject;
            }
        }
    }
    public void Skill2Casting()//위자드
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
                Instantiate(Resources.Load("Player/Adogen"), attackPoint.position, Quaternion.identity, gameObject.transform);
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
