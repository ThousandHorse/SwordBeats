using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof(enemy))]

public class EnemyController : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Vector3 defaultPos;

    //RaycastHit[] _raycastHit = new RaycastHit[10];

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        defaultPos = transform.position;

    }

    public void OnDetectObject(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // �v���C���[�Ɍ������ē���
            agent.destination = collider.transform.position;
            // ����A�j���[�V�����ɐ؂�ւ�
            //animator.SetBool("IsMove", true);
            //animator.GetBool("IsMove");
            //animator.SetTrigger("AttackTrigger");




            //var positionDiff = collider.transform.position - transform.position;
            //var distance = positionDiff.magnitude;
            //var direction = positionDiff.normalized;

            //var hitCount = Physics.RaycastNonAlloc
            //    (transform.position, direction, _raycastHit, distance);

            //// �v���C���[�Ƃ̊Ԃɏ�Q�����Ȃ��ꍇ
            //if (hitCount == 0)
            //{
            //    // �v���C���[�Ɍ������ē���
            //    agent.isStopped = false;
            //    agent.destination = collider.transform.position;
            //}
            //else
            //{
            //    agent.isStopped = true;
            //}

        }
        else
        {
            // �ҋ@�A�j���[�V�����ɐ؂�ւ�
            //animator.SetBool("IsMove", false);
            //agent.destination = defaultPos;
        }
    }
}


