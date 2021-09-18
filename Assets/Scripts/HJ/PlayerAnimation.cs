using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Tooltip("플레이어의 애니메이터 컴포넌트를 담을 변수")]
    public Animator am;
    [Tooltip("플레이어의 PlayerStats 컴포넌트를 담을 변수")]
    public PlayerStats ps;

    float aniValue;

    void Start()
    {
        if (am == null) am = GetComponentInChildren<Animator>();
        if (ps == null) ps = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ps.moveStateCheck)
        {
            if (ps.dashStateCheck)
                aniValue = Mathf.Lerp(aniValue, 1f, Time.deltaTime * 2.0f);            
            else
                aniValue = Mathf.Lerp(aniValue, 0.5f, Time.deltaTime * 7.0f);
        }
        else
            aniValue = Mathf.Lerp(aniValue, 0f, Time.deltaTime * 7.0f);

        am.SetFloat("MoveAni", aniValue);
    }
}
