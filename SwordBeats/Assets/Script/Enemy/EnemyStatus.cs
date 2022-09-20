using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyStatus : MobStatus
{
    NavMeshAgent agent;
    GameObject uIController;

    protected override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        uIController = GameObject.FindGameObjectWithTag("UIController");
    }

    private void Update()
    {
        //Debug.Log("EnemySpeed: " + agent.velocity.magnitude);
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
        Debug.Log("Wait");
        //Destroy(gameObject);
        uIController.GetComponent<UIController>().IndicateClearText();
        StartCoroutine(MainSceneCoroutine());

    }

    private IEnumerator MainSceneCoroutine()
    {
        yield return new WaitForSeconds(2);
        // ÉÅÉCÉìÉVÅ[ÉìÇ…ñﬂÇÈ
        GetComponent<SceneController>().changeMainScene();
        Destroy(gameObject);
        Debug.Log("Destoried");
    }
}
