using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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

    float delta = 0;
    float span = 3;
    private MobAttack _attack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        _status = GetComponent<EnemyStatus>();
        _rigidbody = GetComponent<Rigidbody>();
        _attack = GetComponent<MobAttack>();
        _rigidbody.isKinematic = true;
        defaultPos = transform.position;
    }

    private void Update()
    {
        // �퓬�V�[���̏ꍇ
        if (SceneManager.GetActiveScene().name.Contains("BattleScene"))
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;
                Debug.Log("EnemyAttack");
                _attack.AttackIfPossible();
            }
        }
        
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
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;

            var hitCount = Physics.RaycastNonAlloc
                (transform.position, direction, _raycastHit, distance, raycastLayerMask);

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
    }

    public void BackFirstPostition(Collider collider)
    {
        // �ŏ��̈ʒu�Ɍ������ē���
        agent.isStopped = false;
        agent.destination = defaultPos;


    }

    
}


