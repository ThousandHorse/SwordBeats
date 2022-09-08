using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]

public class MobAttack : MonoBehaviour
{
    [SerializeField] float attackCooldown = 0.5f;
    [SerializeField] Collider attackCollider;

    MobStatus _status;

    void Start()
    {
        _status = GetComponent<MobStatus>();
    }

    public void AttackIfPossible()
    {
        Debug.Log(_status);
        if (!_status.IsAttackable) return;
        _status.GoToAttackStateIfPossible();
    }

    public void OnAttackRangeEnter(Collider collider)
    {
        Debug.Log("OnAttackRangeEnter");
        AttackIfPossible();
    }

    public void OnAttackStart()
    {
        Debug.Log("OnAttackStart");
        attackCollider.enabled = true;
    }

    public void OnHitAttack(Collider collider)
    {
        Debug.Log("OnHitAttack");
        var targetMob = collider.GetComponent<MobStatus>();
        if (null == targetMob) return;
        targetMob.Damage(1);
    }

    public void OnAttackFinished()
    {
        Debug.Log("OnAttackFinished");
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
        Debug.Log("CooldownCoroutine");
        yield return new WaitForSeconds(attackCooldown);
        _status.GoToNormalStateIfPossible();
    }
}
