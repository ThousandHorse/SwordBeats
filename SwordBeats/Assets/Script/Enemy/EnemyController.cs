using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyStatus))]

public class EnemyController : MonoBehaviour
{
    [SerializeField] LayerMask raycastLayerMask;
    NavMeshAgent agent;
    Animator animator;
    Vector3 defaultPos;

    RaycastHit[] _raycastHit = new RaycastHit[10];

    private EnemyStatus _status;

    Rigidbody _rigidbody;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _status = GetComponent<EnemyStatus>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
        defaultPos = transform.position;
    }

    public void OnDetectObject(Collider collider)
    {
        if (!_status.IsMovable)
        {
            Debug.Log("out of range");
            agent.isStopped = true;

            // ����ɓ����Ȃ��悤�ɂ���
            _rigidbody.isKinematic = true;

            return;
        }

        if (collider.CompareTag("Player"))
        {
            // �v���C���[�Ɍ������ē���
            //agent.destination = collider.transform.position;

            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;

            var hitCount = Physics.RaycastNonAlloc
                (transform.position, direction, _raycastHit, distance, raycastLayerMask);
            //Debug.Log("hitCount:" + hitCount);

            // �v���C���[�Ƃ̊Ԃɏ�Q�����Ȃ��ꍇ
            // TODO: �����v�C��
            if (hitCount <= 2)
            {
                // �v���C���[�Ɍ������ē���
                agent.isStopped = false;
                agent.destination = collider.transform.position;

                // �����蔻������邽�߁AKinematic��OFF�ɂ���
                _rigidbody.isKinematic = false;
            }
            else
            {
                agent.isStopped = true;
            }

        }
        else
        {
            // �ҋ@�A�j���[�V�����ɐ؂�ւ�
            //animator.SetBool("IsMove", false);
            //agent.destination = defaultPos;
        }
    }

    public void BackFirstPostition(Collider collider)
    {
        // �ŏ��̈ʒu�Ɍ������ē���
        agent.isStopped = false;
        agent.destination = defaultPos;


    }

    
}


