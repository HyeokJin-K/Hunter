using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  플레이어 이동 스크립트
public class PlayerMove : MonoBehaviour
{    
    PlayerStats playerStats;
    CharacterController playerController;
    
    Vector3 move;

    public float gravity = -9.8f;
    float totalMoveSpeed;

    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
        playerController = gameObject.GetComponent<CharacterController>();

        totalMoveSpeed = playerStats.moveSpeed;

    }

    void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        move = transform.TransformDirection(move);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            MoveDash();
        }
        else
        {
            totalMoveSpeed = playerStats.moveSpeed;
        }
    }

    private void FixedUpdate()
    {
        playerController.Move(move * totalMoveSpeed * Time.deltaTime);        
        playerController.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
    }

    void MoveDash()
    {
        totalMoveSpeed = playerStats.sprintMoveSpeed * playerStats.moveSpeed;
    }

}

