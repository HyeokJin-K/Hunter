using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  플레이어 체력, 스태미너, 속도... 정보 스크립트
public class PlayerStats : MonoBehaviour
{
    //  플레이어 체력 관련 변수
    [Tooltip("플레이어 체력 Max수치")]
    public int maxHP = 100;
    int hp;    

    //  플레이어 스태미너 관련 변수
    [Tooltip("플레이어 스태미너 Max수치")]
    public int maxMP = 100;
    int mp;

    //  플레이어 이동속도 관련 변수
    [Tooltip("플레이어 기본 이동속도 수치")]
    public float moveSpeed = 2.0f;
    [Tooltip("플레이어 대쉬 이동속도 (기본 이동속도에 곱해서 적용됨)")]
    public float sprintMoveSpeed = 2.0f;

    //  플레이어의 현재 행동상태를 체크하는 변수
    [HideInInspector]
    public bool attackStateCheck;
    [HideInInspector]
    public bool moveStateCheck;
    [HideInInspector]
    public bool dashStateCheck;

    private void Awake()
    {
        hp = maxHP;
        mp = maxMP;
    }

    /// <summary>
    /// 플레이어의 현재 HP값을 가져오는 함수
    /// </summary>
    /// <returns></returns>
    public int GetCurrentHP()
    {
        return hp;
    }

    /// <summary>
    /// 플레이어의 현재 MP값을 가져오는 함수
    /// </summary>
    /// <returns></returns>
    public int GetCurrentMP()
    {
        return mp;
    }

    /// <summary>
    /// value 값을 받아 현재 플레이어의 HP에 더하는 함수
    /// </summary>
    /// <param name="value"></param>
    public void AddHP(int value)
    {
        hp += value;
    }

    /// <summary>
    /// value 값을 받아 현재 플레이어의 MP에 더하는 함수
    /// </summary>
    /// <param name="value"></param>
    public void AddMP(int value)
    {
        mp += value;
    }

    /// <summary>
    /// 플레이어의 HP와 MP를 Max 수치 값으로 초기화하는 함수
    /// </summary>
    public void ResetHMP()
    {
        hp = maxHP;
        mp = maxMP;
    }
}
