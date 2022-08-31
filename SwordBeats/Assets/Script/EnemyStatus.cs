using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyStatus : MobStatus
{
    NavMeshAgent agent;
    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _animator.SetFloat("MoveSpeed", agent.velocity.magnitude);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        StartCoroutine(DestoryCoroutine());
    }

    private IEnumerator DestoryCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
