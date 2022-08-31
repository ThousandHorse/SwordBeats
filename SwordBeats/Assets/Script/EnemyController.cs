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
            // プレイヤーに向かって動く
            agent.destination = collider.transform.position;
            // 走るアニメーションに切り替え
            //animator.SetBool("IsMove", true);
            //animator.GetBool("IsMove");
            //animator.SetTrigger("AttackTrigger");




            //var positionDiff = collider.transform.position - transform.position;
            //var distance = positionDiff.magnitude;
            //var direction = positionDiff.normalized;

            //var hitCount = Physics.RaycastNonAlloc
            //    (transform.position, direction, _raycastHit, distance);

            //// プレイヤーとの間に障害物がない場合
            //if (hitCount == 0)
            //{
            //    // プレイヤーに向かって動く
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
            // 待機アニメーションに切り替え
            //animator.SetBool("IsMove", false);
            //agent.destination = defaultPos;
        }
    }
}


