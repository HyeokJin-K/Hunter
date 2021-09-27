using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossFSM : MonoBehaviour
{
    public enum BossState
    { 
        Sleep,
        Walk,
        BasicAttack,
        FlameAttack,
        Stun,
        Die
    }

    public Transform target;
    public float moveSpeed = 5.0f;
    public float attackRange = 1.0f;
    public BoxCollider basicAttackTrigger;

    public BossState bossState = BossState.Sleep;
    NavMeshAgent agent;
    Animator anim;
    Vector3 targetPos;
    bool isAttack = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        basicAttackTrigger.enabled = false;
    }

    void Update()
    {
        switch (bossState)
        {
            case BossState.Sleep:
                break;
            case BossState.Walk:
                Walk();
                break;
            case BossState.BasicAttack:
                BasicAttack();
                break;
            case BossState.FlameAttack:
                FlameAttack();
                break;
            case BossState.Stun:
                break;
            case BossState.Die:
                break;
            default:
                break;
        }
    }

    void Walk()
    {
        isAttack = false;

        // NavMeshAgent ����
        agent.enabled = true;
        agent.SetDestination(target.position);
        agent.isStopped = false;

        agent.speed = moveSpeed;
        targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);

        // �׻� Ÿ���� �ٶ󺸰� �����Ѵ�.
        transform.LookAt(targetPos);

        // �ȱ� �ִϸ��̼� ����
        anim.SetTrigger("Walk");

        // ���� ��Ÿ� �ȿ� ������ �������� �����Ѵ�.
        if (Vector3.Distance(target.position, transform.position) > attackRange)
        {
            int random = Random.Range(0, 2);

            // �̵� ����
            agent.isStopped = true;

            // 0�̸�, BasicAttack
            if (random == 0)
            {
                bossState = BossState.BasicAttack;
            }
            // 1�̸�, FlameAttack
            else
            {
                bossState = BossState.FlameAttack;
            }
        }
    }

    void BasicAttack() 
    {
        // ������ �� basicAttackTrigger Ű��
        basicAttackTrigger.enabled = true;

        // �⺻ ���� �ִϸ��̼� ����
        anim.SetTrigger("BasicAttack");

        isAttack = true;

        // ���� ���� �� �̵� ���·� ����
        if (isAttack)
        {
            bossState = BossState.Walk;
        }
    }

    void FlameAttack()
    {
        // ��ƼŬ ���� �� �÷��̾ ��ƼŬ�� ������ ���������� (OnParticleCollision)
        // https://funfunhanblog.tistory.com/37

        anim.SetTrigger("FlameAttack");

        isAttack = true;

        // ���� ���� �� �̵� ���·� ����
        if (isAttack)
        {
            bossState = BossState.Walk;
        }
    }
}
