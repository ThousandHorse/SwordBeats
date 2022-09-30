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
        // 戦闘シーンの場合
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
            // 勝手に動かないようにする
            _rigidbody.isKinematic = true;
            return;
        }

        if (collider.CompareTag("Player"))
        {
            // プレイヤーに向かって動く
            var positionDiff = collider.transform.position - transform.position;
            var distance = positionDiff.magnitude;
            var direction = positionDiff.normalized;

            var hitCount = Physics.RaycastNonAlloc
                (transform.position, direction, _raycastHit, distance, raycastLayerMask);

            // プレイヤーとの間に障害物がない場合
            // TODO: 条件要修正
            if (hitCount <= 2)
            {
                // プレイヤーに向かって動く
                agent.isStopped = false;
                agent.destination = collider.transform.position;

                // 当たり判定をつけるため、KinematicをOFFにする
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
        // 最初の位置に向かって動く
        agent.isStopped = false;
        agent.destination = defaultPos;


    }

    
}


