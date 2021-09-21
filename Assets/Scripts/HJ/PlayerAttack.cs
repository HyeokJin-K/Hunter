using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void mydele();

[RequireComponent(typeof(PlayerMove))]
public class PlayerAttack : MonoBehaviour
{
    [Tooltip("플레이어가 사용하는 무기 오브젝트")]
    public GameObject playerWeapon;
    [Tooltip("플레이어 애니메이터")]
    public Animator am;
    [Tooltip("플레이어 무브 스크립트")]
    public PlayerMove pm;

    bool weaponColCheck;
    //  true일 경우에만 공격 입력을 받게하는 bool 변수
    public bool attackInputChance;


    void Start()
    {
        if (am == null) am = GetComponent<Animator>();
        if (pm == null) pm = GetComponent<PlayerMove>();

        attackInputChance = true;

        StartCoroutine(CheckAttackInputChance());
    }

    void Update()
    {
        //  마우스 좌클릭시 해머 공격 패턴 1 시작
        if (Input.GetMouseButtonDown(0))
        {
            HammerSwingPattern1();   
        }
    }

    void TurnOnAttack()
    {
        am.SetBool("AttackBool", false);
        attackInputChance = true;
    }

    void TurnOffAttack()
    {
        attackInputChance = false;
    }

    //  좌클릭을 계속 할 경우 해머 공격 패턴 1 연계
    void HammerSwingPattern1()
    {
        if (am.GetCurrentAnimatorStateInfo(1).IsName("AttackReady") && attackInputChance)
        {
                am.SetBool("AttackBool", true);
                attackInputChance = false;
        }
    }

    //  발도 상태일 때는 공격입력 구간을 항상 On으로 하는 함수
    //  공격중일 때는 PlayerMove의 attackStateCheck변수를 true로 하여 움직이지 못하게 함.
    IEnumerator CheckAttackInputChance()
    {
        while (true)
        {
            if (am.GetCurrentAnimatorStateInfo(2).IsName("SwingReady"))
            {
                attackInputChance = true;
                pm.attackStateCheck = false;
            }
            else if (!am.GetCurrentAnimatorStateInfo(2).IsName("SwingReady"))
            {
                pm.attackStateCheck = true;
            }
            yield return null;
        }
    }
}
